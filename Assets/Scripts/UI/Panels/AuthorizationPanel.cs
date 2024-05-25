using SDK;
using TMPro;
using UnityEngine;

namespace UI.Panels
{
    public class AuthorizationPanel : Panel
    {
        [SerializeField] private Localisation _localisation;
        [SerializeField] private TMP_Text _authorizationName;
        [SerializeField] private TMP_Text _cancelName;
        [SerializeField] private TMP_Text _autorizationText;

        private void Awake()
        {
            _authorizationName.text = _localisation.ChangeLanguage(HashedStrings.AuthorizationNameTr, HashedStrings.AuthorizationNameRu, HashedStrings.AuthorizationNameEn);
            _cancelName.text = _localisation.ChangeLanguage(HashedStrings.CancelNameTr, HashedStrings.CancelNameRu, HashedStrings.CancelNameEn);
            _autorizationText.text = _localisation.ChangeLanguage(HashedStrings.AuthorizationTextTr, HashedStrings.AuthorizationTextRu, HashedStrings.AuthorizationTextEn);
        }
    }
}