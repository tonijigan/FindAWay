using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coin;
}

public class ProgressTest : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    public static ProgressTest instance;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    private void Awake()
    {
        if (instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save(int coin)
    {
        Debug.Log(coin);
        PlayerInfo.Coin = coin;
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}