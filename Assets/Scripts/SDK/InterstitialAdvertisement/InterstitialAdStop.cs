using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDK.InterstitialAdvertisement
{
    public class InterstitialAdStop : MonoBehaviour
    {
        [SerializeField] private SDKPromotionalVideo _promotionalVideo;

        private void OnEnable() =>
            _promotionalVideo.ClosedCallBack += OnLoadScene;


        private void OnDisable() =>
            _promotionalVideo.ClosedCallBack -= OnLoadScene;


        private void OnLoadScene(bool isClosed)
        {
            if (isClosed) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}