using System;

public class ChooseButtonNextScene : AbstractButton
{
    public event Action Clicked;

    protected override void OnClick() => ShowNextScene();

    private void ShowNextScene() => Clicked?.Invoke();
}
