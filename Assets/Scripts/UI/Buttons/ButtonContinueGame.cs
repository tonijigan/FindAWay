using SimpleInputNamespace;
using UnityEngine;
using DG.Tweening;

public class ButtonContinueGame : AbstractButton
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _endValue;
    [SerializeField] private float _duration;

    private void Awake()
    {
        var sequence = DOTween.Sequence();
        const int setLoops = -1;
        sequence.Append(ButtonUI.transform.DOScale(_endValue, _duration).From());
        sequence.Append(ButtonUI.transform.DOScale(_endValue, _duration).SetUpdate(true));
        sequence.SetLoops(setLoops);
        sequence.SetUpdate(true);
    }

    protected override void OnClick() => Continue();

    private void Continue()
    {
        var timeScale = 1f;
        Time.timeScale = timeScale;
        _panelMenu.SetActive(false);
        _joystick.gameObject.SetActive(true);
    }
}