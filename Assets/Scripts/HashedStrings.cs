using UnityEngine;

public static class HashedStrings
{
    private const string ConstIdle = "Idle";
    private const string ConstAlarm = "Alarm";
    private const string ConstWalk = "Walk";
    private const string ConstFalling = "Falling";
    private const string ConstWalkWhitBox = "WalkWhitBox";
    private const string ConstWalkWhitKey = "WalkWhitKey";
    private const string ConstIdleWhitBox = "IdleWhitBox";
    private const string ConstIdleWhitKey = "IdleWhitKey";
    private const string ConstLoad = "Load";
    private const string ConstLeaderBoardName = "LeaderBoardsFindAWay";
    private const string ConstAnonymousNameTr = "Anonim oyuncu";
    private const string ConstAnonymousNameRu = "Анонимный игрок";
    private const string ConstAnonymousNameEn = "Anonymous player";
    private const string ConstAuthorizationNameTr = "Kabul";
    private const string ConstAuthorizationNameRu = "Принять";
    private const string ConstAuthorizationNameEn = "Accept";
    private const string ConstCancelNameTr = "İptal et";
    private const string ConstCancelNameRu = "Отменить";
    private const string ConstCancelNameEn = "Cancel";
    private const string ConstAutorizationTextTr = "Lider tablosunu görüntülemek için giriş yapmanız gerekiyor!";
    private const string ConstAutorizationTextRu = "Для отображения таблицы лидеров, необходимо авторизоваться!";
    private const string ConstAutorizationTextEn = "To display the leaderboard, you need to log in!";

    public static int Idle => Animator.StringToHash(ConstIdle);
    public static int Alarm => Animator.StringToHash(ConstAlarm);
    public static int Walk => Animator.StringToHash(ConstWalk);
    public static int Falling => Animator.StringToHash(ConstFalling);
    public static int WalkWhitBox => Animator.StringToHash(ConstWalkWhitBox);
    public static int WalkWhitKey => Animator.StringToHash(ConstWalkWhitKey);
    public static int IdleWhitBox => Animator.StringToHash(ConstIdleWhitBox);
    public static int IdleWhitKey => Animator.StringToHash(ConstIdleWhitKey);
    public static string Load => ConstLoad;
    public static string LeaderBoardName => ConstLeaderBoardName;
    public static string AnonymousNameTr => ConstAnonymousNameTr;
    public static string AnonymousNameRu => ConstAnonymousNameRu;
    public static string AnonymousNameEn => ConstAnonymousNameEn;
    public static string AuthorizationNameTr => ConstAuthorizationNameTr;
    public static string AuthorizationNameRu => ConstAuthorizationNameRu;
    public static string AuthorizationNameEn => ConstAuthorizationNameEn;
    public static string CancelNameTr => ConstCancelNameTr;
    public static string CancelNameRu => ConstCancelNameRu;
    public static string CancelNameEn => ConstCancelNameEn;
    public static string AutorizationTextTr => ConstAutorizationTextTr;
    public static string AutorizationTextRu => ConstAutorizationTextRu;
    public static string AutorizationTextEn => ConstAutorizationTextEn;
}