using UnityEngine;

public class ButtonExitGame : AbstractButton
{
    public override void Click() => Exit();

    private void Exit() => Application.Quit();
}