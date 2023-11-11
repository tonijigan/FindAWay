using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class ChoosedButtonScene : AbstractButton
{
    [SerializeField] private Image _imageClosedAccess;

    public event UnityAction OnClick;

    public override void Click() => OnClick?.Invoke();

    public void ShowAccessScene(bool isAccess)
    {
        _imageClosedAccess.gameObject.SetActive(isAccess = !isAccess);
    }
}