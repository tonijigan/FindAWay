public class Key : InteractionObject
{
    public override void FollowInstructions() { }

    public void Destroy() => Destroy(gameObject);
}