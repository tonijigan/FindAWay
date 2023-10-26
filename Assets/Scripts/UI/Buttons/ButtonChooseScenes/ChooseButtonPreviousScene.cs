using UnityEngine.Events;

public class ChooseButtonPreviousScene : AbstractButton
{
    public event UnityAction PreviousScene;

    public override void Click() => ShowPreviousScene();

    private void ShowPreviousScene() => PreviousScene?.Invoke();
}