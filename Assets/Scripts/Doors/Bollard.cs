using UnityEngine;

public class Bollard : Door
{
    protected override Vector3 SetPosition()
    {
        float newPositionY = 1.9f;
        StartPositionDoor = _typeDoor.localPosition;
        return NewPositionDoor = Vector3.down * newPositionY;
    }
}