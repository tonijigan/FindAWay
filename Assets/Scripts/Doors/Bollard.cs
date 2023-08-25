using UnityEngine;

public class Bollard : Door
{
    protected override Vector3 SetPosition()
    {
        float newPositionY = 1.9f;
        _startPositionDoor = _typeDoor.localPosition;
        return _newPositionDoor = Vector3.down * newPositionY;
    }
}
