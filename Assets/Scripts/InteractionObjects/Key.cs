public class Key : InteractionObject
{
    public override void FollowInstructions() { }

    public void Enable() => gameObject.SetActive(false);
}