using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSystem;
    [SerializeField] private ThiefDetector _thiefDetector;

    private AudioSource _audioSource;
    private float _volumeChangeSpeed = 1f;
    private Coroutine _volumeCoroutine; 

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _alarmSystem;
        _audioSource.loop = true;
    }

    public void PlayAlarm()
    {
        if (_volumeCoroutine == null)
        {
            int targetVolume = 1;
            _audioSource.Play();
            _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolume));
        }
    }

    public void StopAlarm()
    {
        int targetVolume = 0;

        if (_volumeCoroutine != null) 
        {
            StopCoroutine(_volumeCoroutine);
            _volumeCoroutine = null; 
        }

        _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolume));
        _audioSource.Stop();
    }

    private IEnumerator ChangeVolume(int targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _volumeCoroutine = null; 
    }
}
