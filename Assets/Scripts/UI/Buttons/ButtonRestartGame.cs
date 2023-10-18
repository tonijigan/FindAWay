using IJunior.TypedScenes;
using UnityEngine;

public class ButtonRestartGame : AbstractButton
{
    public override void ButtonClick() => RestartScene();

    private void RestartScene()
    {
        Game.Load();
        float timeScale = 1f;
        Time.timeScale = timeScale;
    }
}