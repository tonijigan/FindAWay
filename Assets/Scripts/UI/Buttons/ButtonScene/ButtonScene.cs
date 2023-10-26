using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScene : AbstractButton
{
    [SerializeField] protected int _sceneNumber;
    [SerializeField] private HashNames _hashNames;

    private float _wait = 0.1f;

    public override void Click() => WorkScene();

    public void WorkScene()
    {
        float timeScale = 1.0f;
        Time.timeScale = timeScale;
        Invoke(_hashNames.Load, _wait);
    }

    private void Load() => SceneManager.LoadScene(_sceneNumber);
}