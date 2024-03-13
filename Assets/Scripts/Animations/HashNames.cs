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
    private const string CLeaderBoardName = "LeaderBoardsFindAWay";
    private const string CAnonymousNameTr = "Anonim oyuncu";
    private const string CAnonymousNameRu = "Анонимный игрок";
    private const string CAnonymousNameEn = "Anonymous player";
    private const string CAuthorizationNameTr = "Kabul";
    private const string CAuthorizationNameRu = "Принять";
    private const string CAuthorizationNameEn = "Accept";
    private const string CCancelNameTr = "İptal et";
    private const string CCancelNameRu = "Отменить";
    private const string CCancelNameEn = "Cancel";
    private const string CAutorizationTextTr = "Lider tablosunu görüntülemek için giriş yapmanız gerekiyor!";
    private const string CAutorizationTextRu = "Для отображения таблицы лидеров, необходимо авторизоваться!";
    private const string CAutorizationTextEn = "To display the leaderboard, you need to log in!";

    public static int Idle => Animator.StringToHash(CIdle);
    public static int Alarm => Animator.StringToHash(CAlarm);
    public static int Walk => Animator.StringToHash(CWalk);
    public static int Falling => Animator.StringToHash(CFalling);
    public static int WalkWhitBox => Animator.StringToHash(CWalkWhitBox);
    public static int WalkWhitKey => Animator.StringToHash(CWalkWhitKey);
    public static int IdleWhitBox => Animator.StringToHash(CIdleWhitBox);
    public static int IdleWhitKey => Animator.StringToHash(CIdleWhitKey);
    public static string Load => CLoad;
    public static string LeaderBoardName => CLeaderBoardName;
    public static string AnonymousNameTr => CAnonymousNameTr;
    public static string AnonymousNameRu => CAnonymousNameRu;
    public static string AnonymousNameEn => CAnonymousNameEn;
    public static string AuthorizationNameTr => CAuthorizationNameTr;
    public static string AuthorizationNameRu => CAuthorizationNameRu;
    public static string AuthorizationNameEn => CAuthorizationNameEn;
    public static string CancelNameTr => CCancelNameTr;
    public static string CancelNameRu => CCancelNameRu;
    public static string CancelNameEn => CCancelNameEn;
    public static string AutorizationTextTr => CAutorizationTextTr;
    public static string AutorizationTextRu => CAutorizationTextRu;
    public static string AutorizationTextEn => CAutorizationTextEn;
}