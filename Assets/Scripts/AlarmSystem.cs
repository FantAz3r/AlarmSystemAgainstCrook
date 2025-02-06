using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSystem;
    [SerializeField] private ThiefDetector _thiefDetector;

    private AudioSource _audioSource;
    private float _targetVolume = 0f;
    private float _volumeChangeSpeed = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _alarmSystem;
        _audioSource.loop = true;
    }
   
    public void PlayAlarm()
    {
        StartCoroutine(IncreaceVolume());
    }

    public void StopAlarm()
    {
        StartCoroutine(DecreaceVolume());
    }

    private IEnumerator IncreaceVolume()
    {
        _targetVolume = 1f;
        _audioSource.Play();

        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaceVolume()
    {
        _targetVolume = 0f;

        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
    }
}
