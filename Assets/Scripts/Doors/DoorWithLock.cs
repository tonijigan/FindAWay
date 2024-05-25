using System.Collections;
using UnityEngine;

namespace Doors
{
    public class DoorWithLock : Door
    {
        [SerializeField] private AudioClip _audioOpenLook;
        [SerializeField] private float _speedRotate = 1;

        private void Awake() => SetPosition();

        private void PlayAudioClip(AudioClip audioClip)
        {
            AudioSource.clip = audioClip;
            AudioSource.Play();
        }

        protected override IEnumerator Move(Vector3 newTarget)
        {
            ChangeState();
            PlayAudioClip(_audioOpenLook);
            yield return WaitForSeconds;
            PlayAudioClip(AudioClip);
            yield return WaitForSeconds;

            while (Type.localRotation != Quaternion.Euler(newTarget))
            {
                Type.localRotation = Quaternion.Lerp(Type.localRotation, Quaternion.Euler(newTarget), _speedRotate * Time.deltaTime);
                yield return null;
            }

            AudioSource.Stop();
            StopCoroutine(Coroutine);
        }

        protected override void SetPosition()
        {
            float rotateInPositionZero = 0;
            float rotatePositionY = -90;
            var newPosition = new Vector3(rotateInPositionZero, rotatePositionY, rotateInPositionZero);
            SetPositions(Type.localPosition, newPosition);
        }
    }
}