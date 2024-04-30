using System.Collections.Generic;
using UnityEngine;

namespace ButtonGameObject
{
    public class ButtonsActive : MonoBehaviour
    {
        [SerializeField] private List<ButtonObjectTrigger> _buttonObjectsTriggers;

        public int CountActiveButtons { get; private set; } = 0;

        private void OnEnable()
        {
            foreach (var buttonObject in _buttonObjectsTriggers)
                buttonObject.ButtonActivated += OnSetCountActiveButton;
        }

        private void OnDisable()
        {
            foreach (var buttonObject in _buttonObjectsTriggers)
                buttonObject.ButtonActivated -= OnSetCountActiveButton;
        }

        private void OnSetCountActiveButton(int rewardPerClick) => CountActiveButtons += rewardPerClick;
    }
}