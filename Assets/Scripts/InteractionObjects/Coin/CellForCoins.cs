using UnityEngine;

public class CellForCoins : MonoBehaviour
{
    [SerializeField] private Transform _cell;
    [SerializeField] private Transform _target;

    private Coin[] _coins;

    private void Start() => Initialization();

    private void Initialization()
    {
        _coins = new Coin[_cell.childCount];

        for (var i = 0; i < _coins.Length; i++)
        {
            _coins[i] = _cell.GetChild(i).gameObject.GetComponent<Coin>();
            _coins[i].SetTarget(_target);
        }
    }
}