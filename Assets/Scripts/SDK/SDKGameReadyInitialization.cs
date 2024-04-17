using UnityEngine;

public class SDKGameReadyInitialization : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake()
    {
        Agava.YandexGames.YandexGamesSdk.GameReady();
    }
#endif
}