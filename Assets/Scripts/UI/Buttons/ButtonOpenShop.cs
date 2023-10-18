using UnityEngine;

public class ButtonOpenShop : AbstractButton
{
    [SerializeField] private PanelShop _panelShop;
    [SerializeField] private DynamicJoystick _dynamicJoystick;

    public override void ButtonClick() => OpenPanelShop();

    private void OpenPanelShop()
    {
        _panelShop.gameObject.SetActive(true);
        _dynamicJoystick.gameObject.SetActive(false);
    }
}