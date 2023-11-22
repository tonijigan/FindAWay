using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class LaserSecurityDoor : AbstractDoor
{
    [SerializeField] private LaserSecurity _laserSecurity;
    protected override void SetPosition() { }

    public override IEnumerator MoveDoor(Vector3 newTarget)
    {
        IsOpenDoor = !IsOpenDoor;
        PlayableDirector.Play();
        yield return WaitForSeconds;
        AudioDoor.clip = AudioClip;
        AudioDoor.Play();

        if (IsOpenDoor == true) _laserSecurity.gameObject.SetActive(false);
        else _laserSecurity.gameObject.SetActive(true);

        yield return WaitForSeconds;
        AudioDoor.Stop();
        StopCoroutine(MoveDoor(newTarget));
    }
}