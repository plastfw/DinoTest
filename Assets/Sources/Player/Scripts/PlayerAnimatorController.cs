using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
  private const string IsMoved = "IsMoved";
  private const string Shoot = "Shoot";

  private Animator _animator;

  private void Awake() => _animator = GetComponent<Animator>();

  public void ChangeAnimation(bool state) => _animator.SetBool(IsMoved, state);

  public void ShootAnimation() => _animator.SetTrigger(Shoot);
}