using UnityEngine;

public class buttonTurnOnListener : MonoBehaviour
{
    public void TurnOff()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    public void TurnOn()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1;
    }
}