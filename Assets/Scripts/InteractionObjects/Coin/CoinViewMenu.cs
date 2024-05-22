using TMPro;
using UnityEngine;

namespace InteractionObjects.Coin
{
    public class CoinViewMenu : AbstractDataInit
    {
        [SerializeField] private TMP_Text _data;

        public override void Init(int coins) => _data.text = coins.ToString();
    }
}