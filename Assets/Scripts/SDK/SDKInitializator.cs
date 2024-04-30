using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDK
{
    public class SDKInitializator : MonoBehaviour
    {
        private int _sceneIndex = 1;

        private void Awake() => YandexGamesSdk.CallbackLogging = true;

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized() => SceneManager.LoadScene(_sceneIndex);
    }
}