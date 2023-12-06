using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetPlayerInfo();


    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private RawImage _image;

    private void Start() => GetPlayerInfo();


    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetImage(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    private IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _image.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

        StopCoroutine(DownloadImage(url));
    }
}
