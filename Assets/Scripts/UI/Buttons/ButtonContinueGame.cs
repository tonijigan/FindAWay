using UnityEngine;

public class ButtonContinueGame : AbstractButton
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    public override void ButtonClick() => Continue();

    private void Continue()
    {
        float timeScale = 1f;
        Time.timeScale = timeScale;
        _panelMenu.SetActive(false);
        _dynamicJoystick.gameObject.SetActive(true);
    }
}