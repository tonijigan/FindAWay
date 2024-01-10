using UnityEngine;

[RequireComponent(typeof(SDKPromotionalVideo))]
public class PanelLoss : AbstrapctPanel
{
    private SDKPromotionalVideo _promotionalVideo;

    private void Awake()
    {
        _promotionalVideo = GetComponent<SDKPromotionalVideo>();
        _promotionalVideo.ShowInterstitialAd();
    }
}