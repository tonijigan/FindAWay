using AlarmSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Timer
{
    [RequireComponent(typeof(Image))]
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMinutes;
        [SerializeField] private LaserSecurity _security;
        [SerializeField] private global::UI.Timer.Timer _timer;
        [SerializeField] private Color _timerColor;
        [SerializeField] private Color _textColor;

        private Image _image;

        private void Awake() => _image = GetComponent<Image>();

        private void OnEnable()
        {
            _timer.TimeRunning += OnShowTime;
            _security.IsTriggered += OnChangeColor;
        }

        private void OnDisable()
        {
            _timer.TimeRunning -= OnShowTime;
            _security.IsTriggered -= OnChangeColor;
        }

        private void OnShowTime(float minutes, float seconds) => _textMinutes.text = $"{minutes}:{seconds}";

        private void OnChangeColor(bool isTrigger)
        {
            if (isTrigger != false) return;

            _textMinutes.color = _textColor;
            _image.color = _timerColor;
        }
    }
}