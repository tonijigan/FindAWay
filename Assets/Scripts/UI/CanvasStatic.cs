using SimpleInputNamespace;
using System.Collections;
using UnityEngine;

public class CanvasStatic : MonoBehaviour
{
    [SerializeField] private DoorWithLock _doorWithLock;
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private HaveGround _haveGround;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _waitForSecondsValue = 2;

    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _haveGround.OnFall += OpenMenu;
        _doorWithLock.Opened += OpenMenu;
    }

    private void OnDisable()
    {
        _haveGround.OnFall -= OpenMenu;
        _doorWithLock.Opened -= OpenMenu;
    }

    private void Awake()
    {
        HaveMobilePlatform();
        _waitForSeconds = new WaitForSeconds(_waitForSecondsValue);
    }

    private void HaveMobilePlatform()
    {
        if (Application.isMobilePlatform) _joystick.gameObject.SetActive(true);
        else _joystick.gameObject.SetActive(false);
    }

    private void OpenMenu() => StartCoroutine(Wait());

    private IEnumerator Wait()
    {
        yield return _waitForSeconds;
        TurnOnPanelMenu();
        StopCoroutine(Wait());
    }

    private void TurnOnPanelMenu()
    {
        int timeScale = 0;
        _panelMenu.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        _panelMenu.SwitchButtons();
        Time.timeScale = timeScale;
    }
}