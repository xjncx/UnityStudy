using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    private WaitForSeconds _waitForOneSecond = new WaitForSeconds(1);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarmSound.Play();
            StartCoroutine(ChangeVolume(1));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(ChangeVolume(1));
            StartCoroutine(ChangeVolume(0));
        }
    }

    private IEnumerator ChangeVolume(float direction)
    {
        for (int i = 0; i < 5; i++)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, direction, 0.2f);
            yield return _waitForOneSecond;
        }

        if (direction == 0)
        {
            _alarmSound.Stop();
        }
    }
}
