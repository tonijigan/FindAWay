using UnityEngine;
using Agava.YandexGames;

public class SDKMenu : MonoBehaviour
{
    #if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake()
    {
        YandexGamesSdk.GameReady();
    }
    #endif
}