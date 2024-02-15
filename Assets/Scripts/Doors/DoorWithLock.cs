using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorWithLock : AbstractDoor
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private AudioClip _audioOpenLook;
    [SerializeField] private float _speedRotate = 1;
    [SerializeField] private Timer _timer;

    public event UnityAction Opened;

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
        WorkDoor();
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
        AudioDoor.clip = audioClip;
        AudioDoor.Play();
    }

    protected override IEnumerator MoveDoor(Vector3 newTarget)
    {
        IsOpenDoor = !IsOpenDoor;
        PlayAudioClip(_audioOpenLook);
        yield return WaitForSeconds;
        PlayAudioClip(AudioClip);
        yield return WaitForSeconds;

        while (_typeDoor.localRotation != Quaternion.Euler(newTarget))
        {
            _typeDoor.localRotation = Quaternion.Lerp(_typeDoor.localRotation,
                Quaternion.Euler(newTarget), _speedRotate * Time.deltaTime);
            yield return null;
        }

        AudioDoor.Stop();
        StopCoroutine(Coroutine);
    }

    protected override void SetPosition()
    {
        float rotateInPositionZero = 0;
        float rotatePositionY = -90;
        StartPositionDoor = _typeDoor.localPosition;
        NewPositionDoor = new Vector3(rotateInPositionZero, rotatePositionY, rotateInPositionZero);
    }
}