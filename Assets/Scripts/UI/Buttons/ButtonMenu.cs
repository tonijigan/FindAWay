using UnityEngine;

public class ButtonMenu : AbstractButton
{
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    public override void ButtonClick() => OpenMenu();

    private void OpenMenu()
    {
        float timeScale = 0f;
        _panelMenu.gameObject.SetActive(true);
        _dynamicJoystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }
}