using UnityEngine.Events;

public class ChooseButtonNextScene : AbstractButton
{
    public event UnityAction NextScene;

    protected override void Click() => ShowNextScene();

    private void ShowNextScene() => NextScene?.Invoke();
}
