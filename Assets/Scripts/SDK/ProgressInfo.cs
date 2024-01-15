using System;
using Agava.YandexGames;
using UnityEngine;

public class PlayerInfo
{
    public int Coins;
    public int ScenesAccess = 1;
}

public static class ProgressInfo
{
    public static PlayerInfo PlayerInfo = new PlayerInfo();
    public static event Action ReceivedData, Rewarded;

    public static int MaxCountScenes { get; private set; } = 3;

    public static string JSONString()
    {
        return JsonUtility.ToJson(PlayerInfo);
    }

    public static void GetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        ReceivedData?.Invoke();
    }


    public static void SetCoins(int coins) => PlayerInfo.Coins = coins;

    public static void RewardCoin(int coins)
    {
        PlayerInfo.Coins += coins;
        Rewarded?.Invoke();
    }

    public static void Init(SceneView[] sceneViews)
    {
        for (int i = 0; i < PlayerInfo.ScenesAccess; i++)
        {
            sceneViews[i].HaveAccess();
        }
    }

    public static void OpenAccessNewScene()
    {
        if (PlayerInfo.ScenesAccess < MaxCountScenes) PlayerInfo.ScenesAccess++;
    }
}