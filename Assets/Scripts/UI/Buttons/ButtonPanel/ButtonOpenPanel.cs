using SimpleInputNamespace;
using UnityEngine;

public class ButtonOpenPanel : AbstractButton
{
    [SerializeField] private AbstrapctPanel _panel;
    [SerializeField] private Joystick _joystick;

    public override void Click() => OpenPanel();

    private void OpenPanel()
    {
        float timeScale = 0f;
        _panel.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }
}