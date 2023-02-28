using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerAnimatorController))]
public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private StartPanel _panel;
  [SerializeField] private Path _path;
  [SerializeField] private NavMeshAgent _agent;
  [SerializeField] private EnemyGroup[] _groups;
  [SerializeField] private Gun _gun;
  [SerializeField] private CameraContoller _cameraController;

  private readonly float _rotationSpeed = .2f;

  private PlayerAnimatorController _animatorController;
  private int _currentEnemiesIndex = 0;
  private bool _havePathPoint = false;
  private bool _isMoving = false;
  private Transform _currentPoint;

  public event Action IsFinished;

  private void OnEnable()
  {
    _panel.PanelIsGone += Move;

    foreach (var group in _groups)
      group.AllDied += Move;
  }

  private void OnDisable()
  {
    _panel.PanelIsGone -= Move;

    foreach (var group in _groups)
      group.AllDied -= Move;
  }

  private void Awake() => _animatorController = GetComponent<PlayerAnimatorController>();

  private void FixedUpdate() => CheckPosition();

  public void Rotate(Transform angle, Vector3 target)
  {
    transform
      .DOLookAt(angle.position, _rotationSpeed, AxisConstraint.Y)
      .OnComplete(() =>
      {
        _animatorController.ShootAnimation();
        _gun.Shoot(target);
      });
  }

  private void Move()
  {
    _isMoving = true;
    _gun.ChangeState(false);
    _currentPoint = _path.GetNextPoint();
    _agent.SetDestination(_currentPoint.position);
    _havePathPoint = true;
    _animatorController.ChangeAnimation(_havePathPoint);
    _cameraController.Active3RdPerson();
  }

  private void CheckPosition()
  {
    if (_agent.remainingDistance < float.Epsilon && _isMoving) PreparationBattle();
  }

  private void PreparationBattle()
  {
    _isMoving = false;
    _havePathPoint = false;
    _animatorController.ChangeAnimation(_havePathPoint);
    _gun.ChangeState(true);
    _cameraController.ActiveTransposer();

    if (_currentEnemiesIndex == _groups.Length)
      IsFinished?.Invoke();
    else
    {
      _groups[_currentEnemiesIndex].ShowEnemies();
      _currentEnemiesIndex++;
    }
  }
}