using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMinuts;
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

    private void ShowTime(float minuts, float secunds) => _textMinuts.text = $"{minuts}:{secunds}";

    private void ChangeColor(bool isTrigger)
    {
        if (isTrigger == false)
        {
            _textMinuts.color = _textColor;
            _image.color = _timerColor;
        }
    }
}