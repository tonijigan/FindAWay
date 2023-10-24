using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScene : AbstractButton
{
    [SerializeField] protected int _sceneNumber;

    public override void ButtonClick() => WorkScene();

    public void WorkScene()
    {
        float timeScale = 1.0f;
        SceneManager.LoadScene(_sceneNumber);
        Time.timeScale = timeScale;
    }
}