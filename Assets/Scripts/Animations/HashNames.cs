using System;
using Unity.VisualScripting;
using UnityEngine;

public class HashNames : MonoBehaviour
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

    public int Alarm => Animator.StringToHash(CAlarm);
    public int Idle => Animator.StringToHash(CIdle);
    public int Walk => Animator.StringToHash(CWalk);
    public int Take => Animator.StringToHash(CTake);
    public int Put => Animator.StringToHash(CPut);
    public int Falling => Animator.StringToHash(CFalling);
    public int WalkWhitBox => Animator.StringToHash(CWalkWhitBox);
    public int WalkWhitKey => Animator.StringToHash(CWalkWhitKey);
    public int IdleWhitBox => Animator.StringToHash(CIdleWhitBox);
    public int IdleWhitKey => Animator.StringToHash(CIdleWhitKey);
    public string Load => CLoad;
}