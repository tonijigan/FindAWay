using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public void SetScore(int score)
    {
        if (Agava.YandexGames.PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.SetScore(HashNames.LeaderBoardName, score);
    }
}