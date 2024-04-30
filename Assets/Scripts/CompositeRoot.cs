using Player;
using UI.Timer;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInteractionWithObjects _interactionWithObjects;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Timer _timer;
    [SerializeField] private FocusTracking _focusTracking;

    private void Awake() => _focusTracking.enabled = true;

    private void FixedUpdate()
    {
        _timer.CountDownTime();
        _playerMovement.OnFixedUpdate();
        _interactionWithObjects.OnFixedUpdate();
        _playerAnimations.OnUpdate(_interactionWithObjects.DraggableObject, _interactionWithObjects.IsDragging);
    }
}