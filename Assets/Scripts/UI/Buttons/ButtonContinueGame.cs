using SimpleInputNamespace;
using UnityEngine;

public class ButtonContinueGame : AbstractButton
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Joystick _joystick;
    protected override void Click() => Continue();

    private void Continue()
    {
        var timeScale = 1f;
        Time.timeScale = timeScale;
        _panelMenu.SetActive(false);
        _joystick.gameObject.SetActive(true);
    }
}