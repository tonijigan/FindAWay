using UnityEngine;

public class ButtonExitGame : AbstractButton
{
    public override void ButtonClick() => Exit();

    private void Exit() => Application.Quit();
}