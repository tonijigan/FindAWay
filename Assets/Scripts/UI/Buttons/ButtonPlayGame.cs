using IJunior.TypedScenes;

public class ButtonPlayGame : AbstractButton
{
    public override void ButtonClick() => PlayGame();

    private void PlayGame() => Game.Load();
}