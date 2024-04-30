using System;
using UnityEngine;

namespace UI.Timer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _seconds = 300;
        [SerializeField] private float _secondsPerViolation;

        public event Action TimeIsUped;
        public event Action<float, float> TimeRunning;

        private float _newTime = 1;
        private bool _isUpTime = false;

        public void SetNewTime() => _seconds = _secondsPerViolation;

        public void CountDownTime()
        {
            int minFractionsSeconds = 0;
            int maxFractionsSeconds = 1;
            int secondsInMinutes = 60;
            _newTime -= Time.deltaTime;

            if (_newTime <= minFractionsSeconds && _isUpTime == false)
            {
                _newTime = maxFractionsSeconds;
                _seconds -= maxFractionsSeconds;
            }

            int newTimeMinutes = (int) _seconds / secondsInMinutes;
            float newTimeSeconds = _seconds - (newTimeMinutes * secondsInMinutes);
            TimeRunning?.Invoke(newTimeMinutes, newTimeSeconds);

            if (_seconds != minFractionsSeconds || _isUpTime != false) return;

            TimeIsUped?.Invoke();
            _isUpTime = true;
            this.enabled = false;
        }
    }
}