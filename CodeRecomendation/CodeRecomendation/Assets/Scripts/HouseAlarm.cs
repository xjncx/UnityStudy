using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    private bool _isTurnedOn = false;
    private void Update()
    {

    }
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
        _alarmSound.volume = Mathf.MoveTowards(0, 1, 5f * Time.deltaTime);
        
        yield return new WaitForSeconds(3f);
    }     
}
