using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMinutes;
    [SerializeField] protected LaserSecurity _security;
    [SerializeField] private Timer _timer;
    [SerializeField] private Color _timerColor, _textColor;

    private Image _image;

    private void OnEnable()
    {
        _timer.CurrentTime += ShowTime;
        _security.IsTrigger += ChangeColor;
    }

    private void OnDisable()
    {
        _timer.CurrentTime -= ShowTime;
        _security.IsTrigger -= ChangeColor;
    }

    private void Awake() => _image = GetComponent<Image>();

    private void ShowTime(float minutes, float seconds) => _textMinutes.text = $"{minutes}:{seconds}";

    private void ChangeColor(bool isTrigger)
    {
        if (isTrigger != false) return;

        _textMinutes.color = _textColor;
        _image.color = _timerColor;
    }
}