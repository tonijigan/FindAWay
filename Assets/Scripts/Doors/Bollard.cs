using UnityEngine;

public class Bollard : Door
{
    protected override void SetPosition()
    {
        float newPositionY = 1.9f;
        StartPosition = _type.localPosition;
        NewPosition = Vector3.down * newPositionY;
    }
}