using UnityEngine;

public class AnimationNames : MonoBehaviour
{
    private const string _alarm = "Alarm";
    private const string _idle = "Idle";
    private const string _walk = "Walk";
    private const string _take = "Take";
    private const string _put = "Put";
    private const string _fall = "Fall";

    public string Alarm => _alarm;
    public string Idle => _idle;
    public string Walk => _walk;
    public string Take => _take;
    public string Put => _put;
    public string Fall => _fall;
}
