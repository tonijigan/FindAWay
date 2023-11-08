using SimpleInputNamespace;
using UnityEngine;

public class CanvasStatic : MonoBehaviour
{
    [SerializeField] private DoorWithLock _doorWithLock;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLoss _panelLoss;
    [SerializeField] private HaveGround _haveGround;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Timer _timer;

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

    private void OpenPanelWin() => TurnOnPanel(_panelWin);

    private void OpenPanelLoss() => TurnOnPanel(_panelLoss);

    private void HaveMobilePlatform()
    {
        if (Application.isMobilePlatform) _joystick.gameObject.SetActive(true);
        else _joystick.gameObject.SetActive(false);
    }

    private void TurnOnPanel(AbstrapctPanel abstrapctPanel)
    {
        int timeScale = 0;
        _haveGround.gameObject.SetActive(false);
        abstrapctPanel.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }
}