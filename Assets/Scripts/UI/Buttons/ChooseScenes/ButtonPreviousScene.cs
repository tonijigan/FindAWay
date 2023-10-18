using UnityEngine.Events;

public class ButtonPreviousScene : AbstractButton
{
    public event UnityAction PreviousScene;

    public override void ButtonClick() => ShowPreviousScene();

    private void ShowPreviousScene() => PreviousScene?.Invoke();
}