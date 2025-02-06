using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSystem;
    [SerializeField] private House _house;
    private AudioSource _audioSource;

    private float _targetVolume = 0f; 
    private float _volumeChangeSpeed = 1f; 

    private void OnEnable()
    {
        _house.SomeoneCame += PlayAlarm;
        _house.SomeoneCame += IncreaceVolume;
        _house.BecameEmpty += DecreaceVolume;
    }

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _alarmSystem;
        _audioSource.loop = true; 
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _house.SomeoneCame -= PlayAlarm;
        _house.SomeoneCame -= IncreaceVolume;
        _house.BecameEmpty -= DecreaceVolume;
    }

    private void PlayAlarm()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
    }

    public void IncreaceVolume()
    {
        _targetVolume = 1f;
    }

    public void DecreaceVolume()
    {
        _targetVolume = 0f;
    }
}
