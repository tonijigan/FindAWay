public class Box : InteractionObject
{
    public override void FollowInstructions()
    {
        _isUse = true;
        Rigidbody.isKinematic = !Rigidbody.isKinematic;
    }
}