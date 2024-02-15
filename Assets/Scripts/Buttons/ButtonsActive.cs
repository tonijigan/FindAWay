using System.Collections.Generic;
using UnityEngine;

public class ButtonsActive : MonoBehaviour
{
    [SerializeField] private List<ButtonObject> _buttonObjects;

    public int CountActiveButtons { get; private set; } = 0;

    private void OnEnable()
    {
        foreach (var buttonObject in _buttonObjects)
            buttonObject.ButtonActive += SetCountActiveButton;
    }

    private void OnDisable()
    {
        foreach (var buttonObject in _buttonObjects)
            buttonObject.ButtonActive -= SetCountActiveButton;
    }

    private void SetCountActiveButton(int rewardPerClick) => CountActiveButtons += rewardPerClick;
}