using UnityEngine;

public class CompositRoot : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInteractionWithObjects _interactionWithObjects;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Timer _timer;

    private void FixedUpdate()
    {
        _timer.CountDownTime();
        _playerMovement.OnFixedUpdate();
        _interactionWithObjects.OnFixedUpdate();
        _playerAnimations.OnUpdate(_interactionWithObjects.DraggableObject, _interactionWithObjects.IsDragging);
    }
}