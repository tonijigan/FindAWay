using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ButtonsState))]
public class ButtonRestartScene : AbstractButton
{
    public event UnityAction Clicked;

    private ButtonsState _buttonsState;

    private void Start() => _buttonsState = GetComponent<ButtonsState>();

    protected override void Click() => WorkScene();

    private void WorkScene()
    {
        Clicked?.Invoke();
        _buttonsState.DisableButtons(false);
        var timeScale = 1.0f;
        Time.timeScale = timeScale;
    }
}