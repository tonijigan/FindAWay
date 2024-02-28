using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderBoard : MonoBehaviour
{
    private const string LeaderBoardName = "LeaderBoardsFindAWay";
    private const string AnonymoysName = "Anonymoys";

    private readonly List<LeaderBoardPlayer> _leaderBoardPlayers = new();

    [SerializeField] private LeaderBoaedView _leaderBoaedView;

    public void SetScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetPlayerEntry(HashNames.LeaderBoardName, (result) =>
        {
            if (result.score < score)
                Leaderboard.SetScore(HashNames.LeaderBoardName, score);
        });

        Fill();
    }

    private void Fill()
    {
        if (!PlayerAccount.IsAuthorized) return;

        _leaderBoardPlayers.Clear();

        Leaderboard.GetEntries(LeaderBoardName, result =>
        {
            foreach (var entry in result.entries)
            {
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymoysName;

                _leaderBoardPlayers.Add(new LeaderBoardPlayer(name, score));
            }

            _leaderBoaedView.ConstructLeaderBoard(_leaderBoardPlayers);
        });
    }
}