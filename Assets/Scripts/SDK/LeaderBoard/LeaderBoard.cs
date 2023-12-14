using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderBoardName = "LeaderBoardsFindAWay";
    private readonly List<LeaderBoardPlayer> _leaderBoardPlayers = new();

    [SerializeField] private LeaderBoardView _leaderBoardView;

    public void SetPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderBoardName, onSuccessCallback_ =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderBoardName, score);
        });

        Fill();
    }

    private void Fill()
    {
        _leaderBoardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetEntries(LeaderBoardName, onSuccessCallback: result =>
        {
            foreach (var entry in result.entries)
            {
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderBoardPlayers.Add(new LeaderBoardPlayer(score, name));
            }

            _leaderBoardView.ConstructLeaderBoard(_leaderBoardPlayers);
        });
    }
}