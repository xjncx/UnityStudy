using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Вошел");
            StartCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarmSound.Stop();
        }
    }

    private IEnumerator ChangeVolume()
    {
        _alarmSound.Play();

        for (int i = 0; i < 10; i++)
        {
            _alarmSound.volume = Mathf.MoveTowards(0, 1, 0.1f * Time.deltaTime);
            Debug.Log("Подсчет цикла");
            yield return null;
        }
    }
}
