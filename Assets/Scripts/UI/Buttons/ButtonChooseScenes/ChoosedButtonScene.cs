using UnityEngine.Events;

public class ChoosedButtonScene : AbstractButton
{
    public event UnityAction OnClick;

    public override void Click() => OnClick?.Invoke();
}