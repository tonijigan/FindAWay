using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo { public int Coins; public SceneView[] sceneViews; }

public static class ProgressCoins
{
    public static PlayerInfo PlayerInfo = new PlayerInfo();

    public static string JSONString()
    {
        return JsonUtility.ToJson(PlayerInfo);
    }

    public static void GetPlayerInfo(string value) =>
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);

    public static void SetCoins(int coins) => PlayerInfo.Coins = coins;

    public static void UpdateStateInGlobaleScenes(SceneView[] sceneViews)
    {
        PlayerInfo.sceneViews = new SceneView[sceneViews.Length];

        for (int i = 0; i < PlayerInfo.sceneViews.Length; i++)
        {
            PlayerInfo.sceneViews[i] = sceneViews[i];
        }
    }

    public static void UpdateStateInLocalScenes(SceneView[] sceneViews)
    {
        for (int i = 0; i < sceneViews.Length; i++)
        {
            sceneViews[i] = PlayerInfo.sceneViews[i];
        }
    }
}