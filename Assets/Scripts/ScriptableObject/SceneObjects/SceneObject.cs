using UnityEngine;

[CreateAssetMenu(fileName = "SceneObject", menuName = "NewSceneObject", order = 52)]
public class SceneObject : ScriptableObject
{
    [SerializeField] private Sprite _spriteScene;
    [SerializeField] private int _sceneIndex;

    public Sprite SpriteScene => _spriteScene;
    public int SceneIndex => _sceneIndex;
}