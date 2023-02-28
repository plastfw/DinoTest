using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
  private const float Duration = .5f;

  [SerializeField] private Button _button;
  [SerializeField] private CanvasGroup _canvas;

  public event Action PanelIsGone;

  private void OnEnable() => _button.onClick.AddListener(Hide);

  private void OnDisable() => _button.onClick.RemoveListener(Hide);

  private void Hide()
  {
    _button.interactable = false;

    _canvas.DOFade(0, Duration).OnComplete(() => PanelIsGone?.Invoke());
  }
}