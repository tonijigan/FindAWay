using UnityEngine;
using UnityEngine.UI;
using System;

public class ChoosedButtonScene : AbstractButton
{
    [SerializeField] private Image _imageClosedAccess;

    public event Action Clicked;

    protected override void OnClick() => Clicked?.Invoke();

    public void ShowAccessScene(bool isAccess) => _imageClosedAccess.gameObject.SetActive(isAccess = !isAccess);
}