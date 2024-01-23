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
        int minDolySecunds = 0;
        int maxDolySecunds = 1;
        int secundInMinuts = 60;
        _newTime -= Time.deltaTime;

        if (_newTime <= minDolySecunds && _isUpTime == false)
        {
            _newTime = maxDolySecunds;
            _seconds -= maxDolySecunds;
        }

        var newTimeMinuts = (int) _seconds / secundInMinuts;
        var newTimeSecunds = _seconds - (newTimeMinuts * secundInMinuts);
        CurrentTime?.Invoke(newTimeMinuts, newTimeSecunds);

        if (_seconds != minDolySecunds || _isUpTime != false) return;
        
        TimeIsUp?.Invoke();
        _isUpTime = true;
        this.enabled = false;
    }
}