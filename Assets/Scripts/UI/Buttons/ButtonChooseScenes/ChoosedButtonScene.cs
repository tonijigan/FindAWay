using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.ButtonChooseScenes
{
    public class ChoosedButtonScene : AbstractButton
    {
        [SerializeField] private Image _imageClosedAccess;

        public event Action Clicked;

        public void ShowAccessScene(bool isAccess) => _imageClosedAccess.gameObject.SetActive(isAccess = !isAccess);

        protected override void OnClick() => Clicked?.Invoke();
    }
}