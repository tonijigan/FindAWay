using TMPro;
using UnityEngine;

public class CoinViewMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] protected HashNames _hashNames;

    private void Awake() => _text.text = PlayerPrefs.GetInt(_hashNames.Coins).ToString();
}