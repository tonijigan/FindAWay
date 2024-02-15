using UnityEngine.Events;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _seconds = 300;
    [SerializeField] private float _secondsPerViolation;

    public event UnityAction TimeIsUp;
    public event UnityAction<float, float> CurrentTime;

    private float _newTime = 1;
    private bool _isUpTime = false;

    public void SetNewTime() => _seconds = _secondsPerViolation;

    public void CountDownTime()
    {
        var minFractionsSeconds = 0;
        var maxFractionsSeconds = 1;
        var secondsInMinutes = 60;
        _newTime -= Time.deltaTime;

        if (_newTime <= minFractionsSeconds && _isUpTime == false)
        {
            _newTime = maxFractionsSeconds;
            _seconds -= maxFractionsSeconds;
        }

        var newTimeMinutes = (int) _seconds / secondsInMinutes;
        var newTimeSeconds = _seconds - (newTimeMinutes * secondsInMinutes);
        CurrentTime?.Invoke(newTimeMinutes, newTimeSeconds);

        if (_seconds != minFractionsSeconds || _isUpTime != false) return;

        TimeIsUp?.Invoke();
        _isUpTime = true;
        this.enabled = false;
    }
}