using UnityEngine;

public class ButtonsState : MonoBehaviour
{
    [SerializeField] private AbstractButton[] _abstractButtons;
    [SerializeField] private ButtonRewardAd _buttonRewardAd;
    [SerializeField] private ButtonRestartScene _buttonRestartScene;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    private void OnEnable()
    {
        _buttonRewardAd.RewardClick += DisableButtons;
        _buttonRestartScene.Clicked += DisableButtons;
        _promotionalVideo.RewardPlayed += DisableButtons;
        _promotionalVideo.ClosedCallBack += DisableButtons;
    }

    private void OnDisable()
    {
        _buttonRewardAd.RewardClick -= DisableButtons;
        _buttonRestartScene.Clicked -= DisableButtons;
        _promotionalVideo.RewardPlayed -= DisableButtons;
        _promotionalVideo.ClosedCallBack -= DisableButtons;
    }

    private void DisableButtons(bool isReward)
    {
        foreach (var button in _abstractButtons)
            button.enabled = isReward;

        foreach (var button in _abstractButtons)
            Debug.Log(button.enabled);
    }
}