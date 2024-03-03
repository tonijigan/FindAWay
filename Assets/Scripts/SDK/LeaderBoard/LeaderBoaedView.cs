using System.Collections.Generic;
using UnityEngine;

public class LeaderBoaedView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderBoaredElement _leaderBoardElementPrefab;

    private List<LeaderBoaredElement> _spawnedElements = new List<LeaderBoaredElement>();

    public void ConstructLeaderBoard(List<LeaderBoardPlayer> leaderBoardPlayers)
    {
        ClearLeaderBoard();

        foreach (var player in leaderBoardPlayers)
        {
            LeaderBoaredElement leaderBoaredElementInstance = Instantiate(_leaderBoardElementPrefab, _container);
            leaderBoaredElementInstance.Initialize(player.Name, player.Score);
            _spawnedElements.Add(leaderBoaredElementInstance);
        }
    }

    private void ClearLeaderBoard()
    {
        foreach (var element in _spawnedElements)
            Destroy(element);

        _spawnedElements = new List<LeaderBoaredElement>();
    }
}