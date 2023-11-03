using UnityEngine;

public class ButtonOpenPanel : AbstractButton
{
    [SerializeField] private AbstrapctPanel _panel;

    public override void Click() => OpenPanel();

    private void OpenPanel()
    {
        float timeScale = 0f;
        _panel.gameObject.SetActive(true);
        Time.timeScale = timeScale;
    }
}