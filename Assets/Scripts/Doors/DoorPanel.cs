using System.Collections;
using UnityEngine;

public class DoorPanel : Door
{
    private void Start() => SetPositions();

    private void SetPositions()
    {
        int newPositionX = 1;
        _startPositionDoor = _typeDoor.transform.position;
        _newPositionDoor = _startPositionDoor + new Vector3(newPositionX, 0, 0);
    }
}
