using System;
using UnityEngine;

public static class HashNames
{
    private const string CIdle = "Idle";
    private const string CAlarm = "Alarm";
    private const string CWalk = "Walk";
    private const string CFalling = "Falling";
    private const string CWalkWhitBox = "WalkWhitBox";
    private const string CWalkWhitKey = "WalkWhitKey";
    private const string CIdleWhitBox = "IdleWhitBox";
    private const string CIdleWhitKey = "IdleWhitKey";
    private const string CLoad = "Load";

    public static int Idle => Animator.StringToHash(CIdle);
    public static int Alarm => Animator.StringToHash(CAlarm);
    public static int Walk => Animator.StringToHash(CWalk);
    public static int Falling => Animator.StringToHash(CFalling);
    public static int WalkWhitBox => Animator.StringToHash(CWalkWhitBox);
    public static int WalkWhitKey => Animator.StringToHash(CWalkWhitKey);
    public static int IdleWhitBox => Animator.StringToHash(CIdleWhitBox);
    public static int IdleWhitKey => Animator.StringToHash(CIdleWhitKey);
    public static string Load => CLoad;
}