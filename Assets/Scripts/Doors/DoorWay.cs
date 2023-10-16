using UnityEngine;

public class DoorWay : MonoBehaviour
{
    [SerializeField] private Collider _doorWayWallCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            _doorWayWallCollider.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            _doorWayWallCollider.isTrigger = false;
    }
}