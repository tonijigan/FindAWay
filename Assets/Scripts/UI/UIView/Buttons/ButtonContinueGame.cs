using UnityEngine;

public class ButtonContinueGame : AbstractButton
{
    [SerializeField] private GameObject _panelMenu;

    public override void ButtonClick() => Continue();

    private void Continue()
    {
        float timeScale = 1f;
        Time.timeScale = timeScale;
        _panelMenu.SetActive(false);
    }
}