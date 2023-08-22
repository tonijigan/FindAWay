using UnityEngine;

public class Bollard : Door
{
    protected override Vector3 SetPosition()
    {
        float newPositionY = -1.9f;
        int positionZero = 0;
        _startPositionDoor = _typeDoor.localPosition;
        return _newPositionDoor = new Vector3(positionZero, newPositionY, positionZero);
    }
}
