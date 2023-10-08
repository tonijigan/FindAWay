using UnityEngine;

public class AnimationNames : MonoBehaviour
{
    private const string CAlarm = "Alarm";
    private const string CIdle = "Idle";
    private const string CWalk = "Walk";
    private const string CTake = "Take";
    private const string CPut = "Put";
    private const string CFalling = "Falling";
    private const string CWalkWhitBox = "WalkWhitBox";
    private const string CWalkWhitKey = "WalkWhitKey";
    private const string CIdleWhitBox = "IdleWhitBox";
    private const string CIdleWhitKey = "IdleWhitKey";

    public string Alarm => CAlarm;
    public string Idle => CIdle;
    public string Walk => CWalk;
    public string Take => CTake;
    public string Put => CPut;
    public string Falling => CFalling;
    public string WalkWhitBox => CWalkWhitBox;
    public string WalkWhitKey => CWalkWhitKey;
    public string IdleWhitBox => CIdleWhitBox;
    public string IdleWhitKey => CIdleWhitKey;
}
