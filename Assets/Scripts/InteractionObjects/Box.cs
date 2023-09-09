public class Box : InteractionObject
{
    public override void FollowInstructions()
    {
        Rigidbody.isKinematic = !Rigidbody.isKinematic;
    }
}