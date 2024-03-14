using UnityEngine;

public class ButtonsState : MonoBehaviour
{
    [SerializeField] private AbstractButton[] _abstractButtons;
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;

    private void OnEnable()
    {
        _promotionalVideo.RewardPlayed += DisableButtons;
        _promotionalVideo.ClosedCallBack += DisableButtons;
    }

    private void OnDisable()
    {
        _promotionalVideo.RewardPlayed -= DisableButtons;
        _promotionalVideo.ClosedCallBack -= DisableButtons;
    }

    public void DisableButtons(bool isReward)
    {
        foreach (var button in _abstractButtons)
            button.enabled = isReward;

        foreach (var button in _abstractButtons)
            Debug.Log(button.enabled);
    }
}