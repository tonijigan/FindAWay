using UnityEngine;

namespace UI.Panels
{
    public class PanelPause : Panel
    {
        private void Awake() => Time.timeScale = 0;
    }
}