using UnityEngine;

public class PanelMenu : MonoBehaviour
{
    [SerializeField] private ButtonContinueGame _buttonContinueGame;
    [SerializeField] private ButtonNextScene _buttonNextScene;

    public void SwitchButtons()
    {
        _buttonContinueGame.gameObject.SetActive(false);
        _buttonNextScene.gameObject.SetActive(true);
    }
}
