using UnityEngine;

public class SceneView : MonoBehaviour
{
    [SerializeField] private SceneObject _sceneObject;
    [SerializeField] private bool _isAccess = false;

    public Sprite SpriteScene => _sceneObject.SpriteScene;
    public bool IsAccess => _isAccess;
    public int SceneIndex => _sceneObject.SceneIndex;
    public string SceneName => _sceneObject.SceneName;

    public void HaveAccess() => _isAccess = true;
}