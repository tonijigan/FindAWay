using UnityEngine;

public class DoorPanel : Door
{
    protected override void SetPosition()
    {
        int newPositionX = 1;
        StartPositionDoor = _typeDoor.localPosition;
        NewPositionDoor = Vector3.right * newPositionX;
    }
}