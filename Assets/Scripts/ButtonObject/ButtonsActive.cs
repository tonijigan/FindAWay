using System.Collections.Generic;
using UnityEngine;

public class ButtonsActive : MonoBehaviour
{
    [SerializeField] private List<ButtonObject> _buttonObjects;

    public int CountActiveButtons { get; private set; } = 0;

    private void OnEnable()
    {
        foreach (var buttonObject in _buttonObjects)
            buttonObject.ButtonActivated += OnSetCountActiveButton;
    }

    private void OnDisable()
    {
        foreach (var buttonObject in _buttonObjects)
            buttonObject.ButtonActivated -= OnSetCountActiveButton;
    }

    private void OnSetCountActiveButton(int rewardPerClick) => CountActiveButtons += rewardPerClick;
}
