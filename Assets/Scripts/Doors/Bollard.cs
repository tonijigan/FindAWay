using UnityEngine;

namespace Doors
{
    public class Bollard : Door
    {
        protected override void SetPosition()
        {
            float newPositionY = 1.9f;
            var newPosition = Vector3.down * newPositionY;
            SetPositions(Type.localPosition, newPosition);
        }
    }
}