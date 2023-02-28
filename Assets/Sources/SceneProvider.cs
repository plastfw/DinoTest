using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProvider : MonoBehaviour
{
  [SerializeField] private PlayerMovement _player;

  private void OnEnable() => _player.IsFinished += ReloadScene;

  private void OnDisable() => _player.IsFinished -= ReloadScene;

  private void ReloadScene() => SceneManager.LoadScene(sceneBuildIndex: 0);
}