using UnityEngine;

public class ButtonMenu : AbstractButton
{
    [SerializeField] private GameObject _panelMenu;
    public override void ButtonClick() => OpenMenu();
    private void OpenMenu()
    {
        float timeScale = 0f;
        _panelMenu.SetActive(true);
        Time.timeScale = timeScale;
    }
}