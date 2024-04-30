namespace InteractionObjects
{
    public class Key : InteractionObject
    {
        public void Enable() => gameObject.SetActive(false);
    }
}