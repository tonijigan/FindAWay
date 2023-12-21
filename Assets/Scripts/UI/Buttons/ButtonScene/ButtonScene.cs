using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class ButtonScene : AbstractButton
{
    [SerializeField] protected int _sceneNumber;

    private float _wait = 0.1f;

    public override void Click() => WorkScene();

    public void WorkScene()
    {
        float timeScale = 1.0f;
        Time.timeScale = timeScale;
        Invoke(HashNames.Load, _wait);
    }

    private void Load() => SceneManager.LoadScene(_sceneNumber);
}