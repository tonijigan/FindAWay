using System.Collections;
using UnityEngine;

public class CanvasStatic : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private DoorWithLock _doorWithLock;
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private float _waitForSecondsValue = 2;

    private WaitForSeconds _waitForSeconds;

    private void OnEnable() => _doorWithLock.Opened += OpenMenu;

    private void OnDisable() => _doorWithLock.Opened -= OpenMenu;

    private void Awake() => _waitForSeconds = new WaitForSeconds(_waitForSecondsValue);

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
        _dynamicJoystick.gameObject.SetActive(false);
        _panelMenu.gameObject.SetActive(true);
        _panelMenu.SwitchButtons();
        Time.timeScale = timeScale;
    }
}