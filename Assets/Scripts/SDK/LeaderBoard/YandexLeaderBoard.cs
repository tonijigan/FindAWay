using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderBoard : MonoBehaviour
{
    private readonly List<LeaderBoardPlayer> _leaderBoardPlayers = new List<LeaderBoardPlayer>();

    [SerializeField] private LeaderBoaedView _leaderBoaredView;
    [SerializeField] private Localisation _localisation;

    private void Awake() => Fill();

    public void SetScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetPlayerEntry(HashedStrings.LeaderBoardName, (result) =>
        {
            if (result.score < score)
                Leaderboard.SetScore(HashedStrings.LeaderBoardName, score);
        });
    }

    private void Fill()
    {
        if (!PlayerAccount.IsAuthorized) return;

        _leaderBoardPlayers.Clear();

        Leaderboard.GetEntries(HashedStrings.LeaderBoardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var score = entry.score;
                var playerPublicName = entry.player.publicName;

                if (string.IsNullOrEmpty(playerPublicName))
                    playerPublicName = _localisation.ChangeLanguage(HashedStrings.AnonymousNameTr,
                                        HashedStrings.AnonymousNameRu, HashedStrings.AnonymousNameEn);

                _leaderBoardPlayers.Add(new LeaderBoardPlayer(playerPublicName, score));
            }

            _leaderBoaredView.ConstructLeaderBoard(_leaderBoardPlayers);
        });
    }
}