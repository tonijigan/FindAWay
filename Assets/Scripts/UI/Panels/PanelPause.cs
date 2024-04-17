using UnityEngine;

public class PanelPause : Panel
{
    private void Awake() => Time.timeScale = 0;
}