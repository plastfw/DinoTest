using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  private const float Duration = .5f;

  [SerializeField] private Slider _slider;
  [SerializeField] private CanvasGroup _canvasGroup;
  
  private void Awake() => _canvasGroup = GetComponentInChildren<CanvasGroup>();

  public void Activate(int value)
  {
    _slider.maxValue = value;
    _slider.value = _slider.maxValue;
    _canvasGroup.DOFade(1, Duration);
  }

  public void Deactivate() => _canvasGroup.DOFade(0, Duration);

  public void ChangeValue(int value) => _slider.value = value;
}