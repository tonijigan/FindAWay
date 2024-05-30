using UnityEngine;

namespace Doors
{
    public class Bollard : Door
    {
        protected override void SetPosition()
        {
            float newPositionY = 1.9f;
            Vector3 newPosition = Vector3.down * newPositionY;
            SetPositions(Type.localPosition, newPosition);
        }
    }
}