using System;
using InteractionObjects;
using UnityEngine;

namespace ButtonGameObject
{
    [RequireComponent(typeof(ButtonObject))]
    public class ButtonObjectTrigger : MonoBehaviour
    {
        private ButtonObject _buttonObject;
        private int _rewardPerClick = 1;

        public event Action<int> ButtonActivated;

        private void Awake() => _buttonObject = GetComponent<ButtonObject>();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Box box)) return;
            ButtonActivated?.Invoke(_rewardPerClick);
            _buttonObject.PlayCoroutine();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Box box)) return;
            ButtonActivated?.Invoke(-_rewardPerClick);
            box.ActiveObject();
            _buttonObject.PlayCoroutine();
        }
    }
}