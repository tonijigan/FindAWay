using UnityEngine;

public class Bollard : AbstractDoor
{
    protected override void SetPosition()
    {
        float newPositionY = 1.9f;
        StartPositionDoor = _typeDoor.localPosition;
        NewPositionDoor = Vector3.down * newPositionY;
    }
}