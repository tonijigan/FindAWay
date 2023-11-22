using UnityEngine.Events;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _seconds = 300;
    [SerializeField] private float _secondsPerViolation;

    public event UnityAction TimeIsUp;
    public event UnityAction<float, float> CurrentTime;

    private float _newTime = 1;

    public void SetNewTime() => _seconds = _secondsPerViolation;

    public void CountDownTime()
    {
        int minDolySecunds = 0;
        int maxDolySecunds = 1;
        int secundInMonuts = 60;
        _newTime -= Time.deltaTime;

        if (_newTime <= minDolySecunds)
        {
            _newTime = maxDolySecunds;
            _seconds -= maxDolySecunds;
        }
        var newTimeMinuts = (int)_seconds / secundInMonuts;
        var newTimeSecunds = _seconds - (newTimeMinuts * secundInMonuts);
        CurrentTime?.Invoke(newTimeMinuts, newTimeSecunds);

        if (_seconds == 0)
        {
            TimeIsUp?.Invoke();
            this.enabled = false;
        }
    }
}