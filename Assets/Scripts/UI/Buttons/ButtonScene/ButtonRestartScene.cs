using UnityEngine;
using UnityEngine.Events;

public class ButtonRestartScene : AbstractButton
{
    public event UnityAction<bool> Clicked;

    protected override void Click() => WorkScene();

    private void WorkScene()
    {
        Clicked?.Invoke(false);
        var timeScale = 1.0f;
        Time.timeScale = timeScale;
    }
}