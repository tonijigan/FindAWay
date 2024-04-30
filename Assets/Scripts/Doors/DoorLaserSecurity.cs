using System.Collections;
using AlarmSystem;
using UnityEngine;

namespace Doors
{
    public class DoorLaserSecurity : Door
    {
        [SerializeField] private LaserSecurity _laserSecurity;

        protected override IEnumerator Move(Vector3 newTarget)
        {
            IsOpen = !IsOpen;
            PlayableDirector.Play();
            yield return WaitForSeconds;
            AudioSource.clip = AudioClip;
            AudioSource.Play();

            _laserSecurity.gameObject.SetActive(IsOpen != true);

            yield return WaitForSeconds;
            AudioSource.Stop();
            StopCoroutine(Move(newTarget));
        }
    }
}