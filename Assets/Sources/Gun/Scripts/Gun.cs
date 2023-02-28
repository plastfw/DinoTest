using UnityEngine;

public class Gun : MonoBehaviour
{
  [SerializeField] private Transform _shootPoint;
  [SerializeField] private BulletPool _pool;

  private Bullet _currentBullet;
  private bool _readyToShoot = false;

  public bool ReadyToShoot => _readyToShoot;

  public void ChangeState(bool state) => _readyToShoot = state;

  public void Shoot(Vector3 target)
  {
    _currentBullet = _pool.GetBullet();
    _currentBullet.transform.SetParent(null);
    _currentBullet.transform.position = _shootPoint.position;
    _currentBullet.ChangeState(true);
    _currentBullet.Move(target);
  }
}