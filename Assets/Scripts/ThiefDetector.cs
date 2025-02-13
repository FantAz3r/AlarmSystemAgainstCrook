using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ThiefDetector : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out _))
        {
            _alarmSystem.PlayAlarm(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out _)) 
        {
            _alarmSystem.StopAlarm(); 
        }
    }
}
