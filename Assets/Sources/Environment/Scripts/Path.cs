using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
  [SerializeField] private List<PathPoint> _pathPoints;

  public Transform GetNextPoint()
  {
    var selectablePoint = _pathPoints.FirstOrDefault(p => p.IsUsed == false);

    if (selectablePoint == null) return null;
    
    selectablePoint.ChangeState(true);
    return selectablePoint.transform;
  }
}