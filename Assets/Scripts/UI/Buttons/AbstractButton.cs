using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private AudioSource _audioSource;

    private void OnEnable() => _button.onClick.AddListener(ButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(ButtonClick);

    public abstract void Click();

    public void AccessButton(bool isAccess) => _button.interactable = isAccess;

    public void PlaySound() => _audioSource.Play();

    private void ButtonClick()
    {
        PlaySound();
        Click();
    }
}