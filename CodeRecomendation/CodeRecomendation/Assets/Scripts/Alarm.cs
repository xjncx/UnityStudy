using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _alarmSoundSpeed;

    private WaitForSeconds _waitForMilliSecond = new WaitForSeconds(0.1f);
    private Coroutine _changedVolume;
    private float _minVolume = 0;
    private float _maxVolume = 1;

    public void TurnOn()
    {
        if (_changedVolume != null)
        {
            StopCoroutine(_changedVolume);
        }
        _alarmSound.Play();
        _changedVolume = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void TurnOff()
    {
        StopCoroutine(_changedVolume);
        _changedVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float direction)
    {
        while (_alarmSound.volume != direction)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, direction, _alarmSoundSpeed);
            yield return _waitForMilliSecond;
        }

        if (direction == _minVolume)
        {
            _alarmSound.Stop();
        }
    }
}
