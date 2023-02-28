using System;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
  [SerializeField] private Enemy[] _enemies;
  
  private int _currentEnemies;
  
  public event Action AllDied;

  private void Awake()
  {
    _enemies = GetComponentsInChildren<Enemy>();
    _currentEnemies = _enemies.Length;
  }

  private void OnEnable()
  {
    foreach (var enemy in _enemies)
      enemy.Died += RemoveEnemy;
  }

  private void OnDisable()
  {
    foreach (var enemy in _enemies)
      enemy.Died -= RemoveEnemy;
  }

  private void RemoveEnemy()
  {
    _currentEnemies--;
    
    if(_currentEnemies==0)
      AllDied?.Invoke();
  }

  public void ShowEnemies()
  {
    foreach (var enemy in _enemies)
      enemy.Activate();
  }
}