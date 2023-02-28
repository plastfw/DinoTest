using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
  private const float Duration = .5f;

  [SerializeField] private SkinnedMeshRenderer _renderer;
  [SerializeField] private Collider _collider;
  [SerializeField] private Color[] _targetColors;
  [SerializeField] private int _health;

  private Ragdoll _ragdoll;
  private EnemyAnimator _animator;
  private HealthBar _healthBar;

  public event Action Died;

  private void Awake()
  {
    _ragdoll = GetComponent<Ragdoll>();
    _animator = GetComponent<EnemyAnimator>();
    _healthBar = GetComponent<HealthBar>();
    _collider = GetComponent<Collider>();
    _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
  }

  private void SetColor()
  {
    var colorIndex = Random.Range(0, _targetColors.Length);
    _renderer.material.DOColor(_targetColors[colorIndex], Duration);
  }

  public void Activate()
  {
    _healthBar.Activate(_health);
    SetColor();
    _collider.enabled = true;
  }

  public void GetDamage()
  {
    _health--;
    _healthBar.ChangeValue(_health);

    if (_health != 0) return;

    _animator.Deactivate();
    _ragdoll.Activate();
    _healthBar.Deactivate();
    _collider.enabled = false;
    Died?.Invoke();
  }
}