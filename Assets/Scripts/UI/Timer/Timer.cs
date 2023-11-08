using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _secunds = 300;

    public event UnityAction TimeIsUp;
    public event UnityAction<float, float> CurrentTime;

    private float newTime = 1;

    private void FixedUpdate() => ÑountdownTime();

    public void SetNewTime()
    {
        float newTime = 15;
        _secunds = newTime;
    }

    private void ÑountdownTime()
    {
        int minDolySecunds = 0;
        int maxDolySecunds = 1;
        int secundInMonuts = 60;
        newTime -= Time.deltaTime;

        if (newTime <= minDolySecunds)
        {
            newTime = maxDolySecunds;
            _secunds -= maxDolySecunds;
        }
        var newTimeMinuts = (int)_secunds / secundInMonuts;
        var newTimeSecunds = _secunds - (newTimeMinuts * secundInMonuts);
        CurrentTime?.Invoke(newTimeMinuts, newTimeSecunds);

        if (_secunds == 0)
        {
            TimeIsUp?.Invoke();
            this.enabled = false;
        }
    }
}