using UnityEngine;

public class ButtonClosePanel : AbstractButton
{
    [SerializeField] private PanelShop _panelShop;

    public override void ButtonClick() => ClosePanel();

    private void ClosePanel() => _panelShop.gameObject.SetActive(false);
}