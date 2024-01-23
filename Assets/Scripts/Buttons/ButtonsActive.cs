using System.Collections.Generic;
using UnityEngine;

public class ButtonsActive : MonoBehaviour
{
    [SerializeField] private List<ButtonObject> _buttonObjects;

    public int CountActiveButtons { get; private set; } = 0;

    private void OnEnable()
    {
        for (int i = 0; i < _buttonObjects.Count; i++)
            _buttonObjects[i].ButtonActive += SetCountActiveButton;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonObjects.Count; i++)
            _buttonObjects[i].ButtonActive -= SetCountActiveButton;
    }

    private void SetCountActiveButton(int rewardPerClick) => CountActiveButtons += rewardPerClick;
}