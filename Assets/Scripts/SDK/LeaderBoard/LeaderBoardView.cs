using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderBoardElement _leaderBoardElementPrefab;

    private List<LeaderBoardElement> _spawnedElements = new List<LeaderBoardElement>();

    public void ConstructLeaderBoard(List<LeaderBoardPlayer> leaderBoardPlayers)
    {
        ClearLeaderBoard();

        foreach (LeaderBoardPlayer player in leaderBoardPlayers)
        {
            LeaderBoardElement leaderBoardElementInstantiate =
            Instantiate(_leaderBoardElementPrefab, _container);
            leaderBoardElementInstantiate.Initialize(player.Name, player.Coins);
            _spawnedElements.Add(leaderBoardElementInstantiate);
        }
    }

    private void ClearLeaderBoard()
    {
        foreach (var element in _spawnedElements) Destroy(element);

        _spawnedElements = new List<LeaderBoardElement>();
    }
}