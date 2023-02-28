using UnityEngine;

public class PathPoint : MonoBehaviour,IChangingState
{
  [SerializeField] private bool _isUsed = false;

  public bool IsUsed => _isUsed;

  public void ChangeState(bool state) => _isUsed = state;
}
