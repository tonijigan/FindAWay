using UnityEngine;

public static class HashNames
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
    private const string CLoad = "Load";
    private const string CCoins = "Coins";
    private const string CAudioListenerState = "AudioListenerState";

    public static int Alarm => Animator.StringToHash(CAlarm);
    public static int Idle => Animator.StringToHash(CIdle);
    public static int Walk => Animator.StringToHash(CWalk);
    public static int Take => Animator.StringToHash(CTake);
    public static int Put => Animator.StringToHash(CPut);
    public static int Falling => Animator.StringToHash(CFalling);
    public static int WalkWhitBox => Animator.StringToHash(CWalkWhitBox);
    public static int WalkWhitKey => Animator.StringToHash(CWalkWhitKey);
    public static int IdleWhitBox => Animator.StringToHash(CIdleWhitBox);
    public static int IdleWhitKey => Animator.StringToHash(CIdleWhitKey);
    public static string Load => CLoad;
    public static string Coins => CCoins;
    public static string AudioListenerState => CAudioListenerState;
}