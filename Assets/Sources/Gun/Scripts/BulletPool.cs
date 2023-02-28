using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
  [SerializeField] private List<Bullet> _bullets;

  public Bullet GetBullet()
  {
    var selectableBullet = _bullets.FirstOrDefault(p => p.gameObject.activeSelf == false);

    return selectableBullet == null ? null : selectableBullet;
  }
}