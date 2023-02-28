using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour, IChangingState
{
  private readonly float _speed = .3f;

  [SerializeField] private BulletPool _pool;

  public void ChangeState(bool state) => gameObject.SetActive(true);

  public void Move(Vector3 target) => transform.DOMove(target, _speed).OnComplete((() => Deactivate()));

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.TryGetComponent(out Enemy enemy))
      enemy.GetDamage();

    Deactivate();
    transform.SetParent(_pool.transform);
  }

  private void Deactivate() => gameObject.SetActive(false);
}