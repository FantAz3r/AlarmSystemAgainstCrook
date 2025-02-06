using System;
using UnityEngine;

public class Glass : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _wholeObject; 
    [SerializeField] private GameObject _brokenObject; 
    [SerializeField] private int _health = 1;

    public void Interact()
    {
        _wholeObject.SetActive(false);
        _brokenObject.SetActive(true);
        Destroy(GetComponent<Collider>());
    }
}

