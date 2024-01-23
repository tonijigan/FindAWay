using UnityEngine;

public class ButtonClosePanel : AbstractButton
{
    [SerializeField] private AbstrapctPanel _panel;

    protected override void Click() => ClosePanel();

    private void ClosePanel() => _panel.gameObject.SetActive(false);
}