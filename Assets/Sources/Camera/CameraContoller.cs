using UnityEngine;

public class CameraContoller : MonoBehaviour
{
  private const string Third = "3rd";
  private const string Tranposer = "Transposer";

  [SerializeField] private Animator _animator;

  private void Start() => Active3RdPerson();

  public void Active3RdPerson() => _animator.Play(Third);

  public void ActiveTransposer() => _animator.Play(Tranposer);
}