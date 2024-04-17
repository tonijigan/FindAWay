using System;
using System.Collections;
using UnityEngine;

public class DoorWithLock : Door
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private AudioClip _audioOpenLook;
    [SerializeField] private float _speedRotate = 1;
    [SerializeField] private Timer _timer;

    public event Action Opened;

    private bool _isClose = true;

    private void Awake() => SetPosition();

    public bool TryOpenDoor(InteractionObject interactionObject)
    {
        if (interactionObject == null)
            return _isClose;
        else
        {
            if (interactionObject.TryGetComponent(out Key key))
                UseKey(key);

            return _isClose;
        }
    }

    private void UseKey(Key key)
    {
        Destroy(_timer.gameObject);
        SaveProgress();
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.PlayerAccount.SetCloudSaveData(ProgressInfo.JSONString());
#endif
        key.Enable();
        Work();
        Opened?.Invoke();
        _isClose = false;
    }

    private void SaveProgress()
    {
        ProgressInfo.SetCoins(_wallet.CountCoins);
        ProgressInfo.OpenAccessNewScene();
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }

    protected override IEnumerator Move(Vector3 newTarget)
    {
        IsOpen = !IsOpen;
        PlayAudioClip(_audioOpenLook);
        yield return WaitForSeconds;
        PlayAudioClip(AudioClip);
        yield return WaitForSeconds;

        while (_type.localRotation != Quaternion.Euler(newTarget))
        {
            _type.localRotation = Quaternion.Lerp(_type.localRotation,
                Quaternion.Euler(newTarget), _speedRotate * Time.deltaTime);
            yield return null;
        }

        AudioSource.Stop();
        StopCoroutine(Coroutine);
    }

    protected override void SetPosition()
    {
        float rotateInPositionZero = 0;
        float rotatePositionY = -90;
        StartPosition = _type.localPosition;
        NewPosition = new Vector3(rotateInPositionZero, rotatePositionY, rotateInPositionZero);
    }
}