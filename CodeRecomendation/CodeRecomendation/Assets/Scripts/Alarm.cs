using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//3.HouseAlarm - Сирена не должна проверять что в нее кто то вошел это ответственность двери
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _alarmSoundSpeed;

    private WaitForSeconds _waitForOneSecond = new WaitForSeconds(1);
    private Coroutine _changedVolume;

    public void TurnOnAlarm()
    {
        if (_changedVolume != null)
        {
            StopCoroutine(_changedVolume);
        }
        _alarmSound.Play();
        _changedVolume = StartCoroutine(ChangeVolume(1));
    }

    public void TurnOffAlarm()
    {
        StopCoroutine(_changedVolume);
        _changedVolume = StartCoroutine(ChangeVolume(0));
    }

    private IEnumerator ChangeVolume(float direction)
    {
        for (int i = 0; i < 5; i++)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, direction, _alarmSoundSpeed);
            yield return _waitForOneSecond;
        }

        if (direction == 0)
        {
            _alarmSound.Stop();
        }
    }
}
