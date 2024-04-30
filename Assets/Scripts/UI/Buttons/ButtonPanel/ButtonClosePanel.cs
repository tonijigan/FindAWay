using UI.Panels;
using UnityEngine;

namespace UI.Buttons.ButtonPanel
{
    public class ButtonClosePanel : AbstractButton
    {
        [SerializeField] private Panel _panel;
    
        protected override void OnClick() => ClosePanel();

        private void ClosePanel() => _panel.gameObject.SetActive(false);
    }
}