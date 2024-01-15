using UnityEngine;
using UnityEngine.Serialization;

public class ButtonsActive : MonoBehaviour
{
    [SerializeField] private ButtonObject[] _buttonObjects;

    public int CountActiveButtons { get; private set; } = 0;

    private void OnEnable()
    {
        for (int i = 0; i < _buttonObjects.Length; i++)
            _buttonObjects[i].ButtonClick += SetCountActiveButton;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonObjects.Length; i++)
            _buttonObjects[i].ButtonClick -= SetCountActiveButton;
    }

    private void SetCountActiveButton(bool active) => CountActiveButtons++;
}