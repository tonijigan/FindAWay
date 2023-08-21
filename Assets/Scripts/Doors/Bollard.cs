using UnityEngine;

public class Bollard : Door
{
    protected override Vector3 SetPosition()
    {
        float newPositionY = -1.9f;
        int positionZero = 0;
        _startPositionDoor = _typeDoor.transform.position;
        return _newPositionDoor = _startPositionDoor + new Vector3(positionZero, newPositionY, positionZero);
    }
}
