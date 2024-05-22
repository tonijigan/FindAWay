using ScriptableObject;
using UnityEngine;

namespace UI.Scenes
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private SceneObject _sceneObject;
        [SerializeField] private bool _isAccess = false;

        public Sprite SpriteScene => _sceneObject.SpriteScene;
        public bool IsAccess => _isAccess;
        public int SceneIndex => _sceneObject.SceneIndex;

        public void OpenAccess() => _isAccess = true;
    }
}