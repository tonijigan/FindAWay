using System.Runtime.InteropServices;
using UnityEngine;

public class NewYandexTest : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();

    public void RateGameButton()
    {
        RateGame();
    }
}
