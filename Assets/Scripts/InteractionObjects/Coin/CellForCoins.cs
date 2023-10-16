using UnityEngine;

public class CellForCoins : MonoBehaviour
{
    [SerializeField] private Transform _cell;
    [SerializeField] private Transform _target;

    private Coin[] _coins;

    private void Start()
    {
        Initialization();
        SetCoinsTarget();
    }

    private void Initialization()
    {
        _coins = new Coin[_cell.childCount];

        for (int i = 0; i < _coins.Length; i++)
            _coins[i] = _cell.GetChild(i).gameObject.GetComponent<Coin>();
    }

    private void SetCoinsTarget()
    {
        for (int i = 0; i < _coins.Length; i++)
            _coins[i].SetTarget(_target);
    }
}