using TMPro;
using UnityEngine;
using Agava.YandexGames;

public class SDKMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
#if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake()
    {
        YandexGamesSdk.GameReady();
        PlayerAccount.GetCloudSaveData(OnSuccessCallback);
    }
#endif
    
    private void OnSuccessCallback(string data)
    {
        _text.text = data;
        int.TryParse(data, out int coins);
        StaticCoins.SetCoins(coins);
    }
}