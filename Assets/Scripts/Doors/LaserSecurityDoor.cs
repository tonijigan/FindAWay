using System.Collections;
using UnityEngine;

public class LaserSecurityDoor : AbstractDoor
{
    [SerializeField] private LaserSecurity _laserSecurity;
    protected override void SetPosition() { }

    protected override IEnumerator MoveDoor(Vector3 newTarget)
    {
        IsOpenDoor = !IsOpenDoor;
        PlayableDirector.Play();
        yield return WaitForSeconds;
        AudioDoor.clip = AudioClip;
        AudioDoor.Play();

        _laserSecurity.gameObject.SetActive(IsOpenDoor != true);

        yield return WaitForSeconds;
        AudioDoor.Stop();
        StopCoroutine(MoveDoor(newTarget));
    }
}