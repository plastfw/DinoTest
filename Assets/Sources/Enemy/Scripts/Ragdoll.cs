using DG.Tweening;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
  [SerializeField] private Rigidbody[] _rigidbodies;
  [SerializeField] private Collider[] _colliders;

  private void Start() => Deactivate();

  public void Activate()
  {
    foreach (var collider in _colliders)
      collider.enabled = true;

    foreach (var rigidbody in _rigidbodies)
      rigidbody.isKinematic = false;
  }

  private void Deactivate()
  {
    foreach (var collider in _colliders)
      collider.enabled = false;

    foreach (var rigidbody in _rigidbodies)
      rigidbody.isKinematic = true;
  }
}