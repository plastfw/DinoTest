using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
  [SerializeField] private AnimationClip[] _clips;

  private Animator _animator;

  private void Awake()
  {
    _animator = GetComponent<Animator>();
    SetAnimationClip();
  }

  private void SetAnimationClip()
  {
    var index = Random.Range(0, _clips.Length);
    _animator.Play(_clips[index].name);
  }

  public void Deactivate() => _animator.enabled = false;
}