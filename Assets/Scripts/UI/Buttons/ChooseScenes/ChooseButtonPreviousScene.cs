using UnityEngine.Events;

public class ChooseButtonPreviousScene : AbstractButton
{
    public event UnityAction PreviousScene;

    public override void ButtonClick() => ShowPreviousScene();

    private void ShowPreviousScene() => PreviousScene?.Invoke();
}