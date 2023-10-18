using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable() => _button.onClick.AddListener(ButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(ButtonClick);

    public abstract void ButtonClick();
}