using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonResetProgress : AbstractButton
{
    [SerializeField] private SceneView[] _sceneViews;
    public override void Click()
    {
        int minCoins = 0;
        int accessStatus = 0;
        PlayerPrefs.SetInt(HashNames.Coins, minCoins);

        for (int i = 0; i < _sceneViews.Length; i++)
            PlayerPrefs.SetInt(_sceneViews[i].SceneName, accessStatus);

        SceneManager.LoadScene(0);
    }
}