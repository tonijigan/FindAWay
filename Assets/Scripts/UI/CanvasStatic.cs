using SimpleInputNamespace;
using System.Collections;
using UnityEngine;

public class CanvasStatic : MonoBehaviour
{
    [SerializeField] private DoorWithLock _doorWithLock;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLoss _panelLoss;
    [SerializeField] private HaveGround _haveGround;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Timer _timer;

    private Coroutine _coroutine;
    private float _waitForOpenPanelWin = 1.5f;

    private void OnEnable()
    {
        _doorWithLock.Opened += OpenPanelWin;
        _haveGround.OnFall += OpenPanelLoss;
        _timer.TimeIsUp += OpenPanelLoss;
    }

    private void OnDisable()
    {
        _doorWithLock.Opened -= OpenPanelWin;
        _haveGround.OnFall -= OpenPanelLoss;
        _timer.TimeIsUp -= OpenPanelLoss;
    }

    private void Awake() => HaveMobilePlatform();

    private void OpenPanelWin() => PlayCoroutine(_panelWin, _waitForOpenPanelWin);

    private void OpenPanelLoss() => PlayCoroutine(_panelLoss);

    private void HaveMobilePlatform()
    {
        if (Application.isMobilePlatform) _joystick.gameObject.SetActive(true);
        else _joystick.gameObject.SetActive(false);
    }

    private void PlayCoroutine(AbstrapctPanel abstrapctPanel, float wait = 0)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TurnOnPanel(_panelWin, wait));
    }

    private IEnumerator TurnOnPanel(AbstrapctPanel abstrapctPanel, float wait)
    {
        yield return new WaitForSeconds(wait);
        int timeScale = 0;
        _haveGround.gameObject.SetActive(false);
        abstrapctPanel.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
        StopCoroutine(TurnOnPanel(abstrapctPanel, wait));
    }
}