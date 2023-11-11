using UnityEngine;

[CreateAssetMenu(fileName = "SceneObject", menuName = "NewSceneObject", order = 52)]
public class SceneObject : ScriptableObject
{
    [SerializeField] private Sprite _spriteScene;
    [SerializeField] private int _sceneIndex;
    [SerializeField] private bool _isAccess = false;

    public Sprite SpriteScene => _spriteScene;
    public bool IsAccess => _isAccess;
    public int SceneIndex => _sceneIndex;

    public void OpenAccess() => _isAccess = true;
}