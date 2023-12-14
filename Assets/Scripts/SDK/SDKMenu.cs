using UnityEngine;

public class SDKMenu : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake() => Agava.YandexGames.YandexGamesSdk.GameReady();
#endif
}