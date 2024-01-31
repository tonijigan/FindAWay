using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScene : AbstractButton
{
    [SerializeField] protected int _sceneNumber;

    private float _wait = 0.1f;

    protected override void Click() => WorkScene();

    private void WorkScene()
    {
        var timeScale = 1.0f;
        Time.timeScale = timeScale;
        Invoke(HashNames.Load, _wait);
    }

    public void Load() => SceneManager.LoadScene(_sceneNumber);
}