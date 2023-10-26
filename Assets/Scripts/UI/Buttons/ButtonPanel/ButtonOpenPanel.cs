using UnityEngine;

public class ButtonOpenPanel : AbstractButton
{
    [SerializeField] private AbstrapctPanel _panel;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    public override void Click() => OpenPanel();

    private void OpenPanel()
    {
        float timeScale = 0f;
        _panel.gameObject.SetActive(true);
        _dynamicJoystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }
}