using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//3.HouseAlarm - Сирена не должна проверять что в нее кто то вошел это ответственность двери
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _alarmSoundSpeed;

    private WaitForSeconds _waitForMilliSecond = new WaitForSeconds(0.1f);
    private Coroutine _changedVolume;
    private float _decreaseVolume = 0;
    private float _increaseVolume = 1;

    public void TurnOnAlarm()
    {
        if (_changedVolume != null)
        {
            StopCoroutine(_changedVolume);
        }
        _alarmSound.Play();
        _changedVolume = StartCoroutine(ChangeVolume(_increaseVolume));
    }

    public void TurnOffAlarm()
    {
        StopCoroutine(_changedVolume);
        _changedVolume = StartCoroutine(ChangeVolume(_decreaseVolume));
    }

    private IEnumerator ChangeVolume(float direction)
    {
        while (_alarmSound.volume != direction)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, direction, _alarmSoundSpeed);
            yield return _waitForMilliSecond;
        }

        if (direction == _decreaseVolume)
        {
            _alarmSound.Stop();
        }
    }
}
