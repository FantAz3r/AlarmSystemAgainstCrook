using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class House : MonoBehaviour
{
    public event Action SomeoneCame;
    public event Action BecameEmpty;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement)) 
        {
            SomeoneCame?.Invoke(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement) 
        {
            BecameEmpty?.Invoke();
        }
    }
}

