using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializator : MonoBehaviour
{
    private void Awake() => YandexGamesSdk.CallbackLogging = true;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialized);
    }

    private void OnInitialized() => SceneManager.LoadScene(1);
}   