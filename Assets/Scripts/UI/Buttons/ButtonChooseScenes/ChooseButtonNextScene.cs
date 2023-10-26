using UnityEngine.Events;

public class ChooseButtonNextScene : AbstractButton
{
    public event UnityAction NextScene;

    public override void Click() => ShowNextScene();

    private void ShowNextScene() => NextScene?.Invoke();
}
