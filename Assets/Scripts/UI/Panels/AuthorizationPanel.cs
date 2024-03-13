using TMPro;
using UnityEngine;

public class AuthorizationPanel : AbstrapctPanel
{
    [SerializeField] private Localisation _localisation;
    [SerializeField] private TMP_Text _authorizationName, _cancelName, _autorizationText;

    private void Awake()
    {
        _authorizationName.text = _localisation.ChangeLanguage(HashNames.AuthorizationNameTr,
            HashNames.AuthorizationNameRu, HashNames.AuthorizationNameEn);
        _cancelName.text = _localisation.ChangeLanguage(HashNames.CancelNameTr,
                HashNames.CancelNameRu, HashNames.CancelNameEn);
        _autorizationText.text = _localisation.ChangeLanguage(HashNames.AutorizationTextTr,
            HashNames.AutorizationTextRu, HashNames.AutorizationTextEn);
    }
}