using System.Collections.Generic;
using UnityEngine;

namespace SDK.LeaderBoard
{
    public class LeaderBoaedView : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private LeaderBoardElement _leaderBoardElementPrefab;

        private List<LeaderBoardElement> _spawnedElements = new List<LeaderBoardElement>();

        public void ConstructLeaderBoard(List<LeaderBoardPlayer> leaderBoardPlayers)
        {
            ClearLeaderBoard();

            foreach (var player in leaderBoardPlayers)
            {
                LeaderBoardElement leaderBoardElementInstance = Instantiate(_leaderBoardElementPrefab, _container);
                leaderBoardElementInstance.Initialize(player.Name, player.Score);
                _spawnedElements.Add(leaderBoardElementInstance);
            }
        }

        private void ClearLeaderBoard()
        {
            foreach (var element in _spawnedElements)
                Destroy(element);

            _spawnedElements = new List<LeaderBoardElement>();
        }
    }
}