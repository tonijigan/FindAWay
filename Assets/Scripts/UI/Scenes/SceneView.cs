using UnityEngine;

public class SceneView : MonoBehaviour
{
    [SerializeField] private SceneObject _sceneObject;
    [SerializeField] private bool _isAccess = false;

    public Sprite SpriteScene => _sceneObject.SpriteScene;
    public bool IsAccess => _isAccess;
    public int SceneIndex => _sceneObject.SceneIndex;
    public string SceneName => _sceneObject.SceneName;

    private void Start() => HaveAccess();

    private void HaveAccess()
    {
        int _accessStatusFalse = 0;

        if (PlayerPrefs.GetInt(_sceneObject.name) == _accessStatusFalse && _isAccess != true)
            _isAccess = false;
        else
            _isAccess = true;
    }
}