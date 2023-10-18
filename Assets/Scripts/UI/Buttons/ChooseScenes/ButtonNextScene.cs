using UnityEngine.Events;

public class ButtonNextScene : AbstractButton
{
    public event UnityAction NextScene;

    public override void ButtonClick() => ShowNextScene();

    private void ShowNextScene() => NextScene?.Invoke();
}
