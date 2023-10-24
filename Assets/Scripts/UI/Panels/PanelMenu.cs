using UnityEngine;

public class PanelMenu : AbstrapctPanel
{
    [SerializeField] private ButtonContinueGame _buttonContinueGame;
    [SerializeField] private ButtonScene _buttonNextScene;

    public void SwitchButtons()
    {
        _buttonContinueGame.gameObject.SetActive(false);
        _buttonNextScene.gameObject.SetActive(true);
    }
}
