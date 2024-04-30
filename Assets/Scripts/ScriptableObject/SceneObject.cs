using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "SceneObject", menuName = "NewSceneObject", order = 52)]
    public class SceneObject : UnityEngine.ScriptableObject
    {
        [SerializeField] private Sprite _spriteScene;
        [SerializeField] private int _sceneIndex;

        public Sprite SpriteScene => _spriteScene;
        public int SceneIndex => _sceneIndex;
        public string SceneName => this.name;
    }
}