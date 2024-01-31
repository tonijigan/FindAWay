using UnityEngine;
using UnityEngine.Events;

public class ButtonRestartScene : AbstractButton
{
    public event UnityAction Clicked;

    protected override void Click() => WorkScene();

    private void WorkScene()
    {
        Clicked?.Invoke();
        var timeScale = 1.0f;
        Time.timeScale = timeScale;
    }
}