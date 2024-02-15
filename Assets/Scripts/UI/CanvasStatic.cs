using System.Collections;
using UnityEngine;

public class CanvasStatic : MonoBehaviour
{
    [SerializeField] private DoorWithLock _doorWithLock;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLoss _panelLoss;
    [SerializeField] private HaveGround _haveGround;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private Timer _timer;

    private Coroutine _coroutine;
    private float _waitForOpenPanelWin = 1.5f;

    private void OnEnable()
    {
        _doorWithLock.Opened += OpenPanelWin;
        _haveGround.Fall += OpenPanelLoss;
        _timer.TimeIsUp += OpenPanelLoss;
    }

    private void OnDisable()
    {
        _doorWithLock.Opened -= OpenPanelWin;
        _haveGround.Fall -= OpenPanelLoss;
        _timer.TimeIsUp -= OpenPanelLoss;
    }

    private void Awake() => HaveMobilePlatform();

    private void OpenPanelWin() => PlayCoroutine(_panelWin);

    private void OpenPanelLoss() => PlayCoroutine(_panelLoss, true);

    private void HaveMobilePlatform()
    {
        _joystick.gameObject.SetActive(Application.isMobilePlatform);
    }

    private void PlayCoroutine(AbstrapctPanel abstractPanel, bool isLoss = false)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TurnOnPanel(abstractPanel, isLoss));
    }

    private IEnumerator TurnOnPanel(AbstrapctPanel abstractPanel, bool isLoss)
    {
        if (isLoss == false)
            yield return new WaitForSeconds(_waitForOpenPanelWin);

        var timeScale = 0;
        _haveGround.gameObject.SetActive(false);
        abstractPanel.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
        StopCoroutine(TurnOnPanel(abstractPanel, isLoss));
    }
}