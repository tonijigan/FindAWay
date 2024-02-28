using System.Collections.Generic;
using UnityEngine;

public class LeaderBoaedView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderBoaedElement _leaderBoaedElementPrefab;

    private List<LeaderBoaedElement> _spawnedElements = new();

    public void ConstructLeaderBoard(List<LeaderBoardPlayer> leaderBoardPlayers)
    {
        ClearLeaderBoard();

        foreach (var player in leaderBoardPlayers)
        {
            LeaderBoaedElement leaderBoaedElementInstance = Instantiate(_leaderBoaedElementPrefab, _container);
            leaderBoaedElementInstance.Initialize(player.Name, player.Score);

            _spawnedElements.Add(leaderBoaedElementInstance);
        }
    }

    private void ClearLeaderBoard()
    {
        foreach (var element in _spawnedElements)
            Destroy(element);

        _spawnedElements = new List<LeaderBoaedElement>();
    }
}