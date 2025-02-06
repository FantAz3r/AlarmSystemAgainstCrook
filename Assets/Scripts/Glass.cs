using UnityEngine;

public class Glass : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _wholeObject; 
    [SerializeField] private GameObject _brokenObject; 

    public void Interact()
    {
        _wholeObject.SetActive(false);
        _brokenObject.SetActive(true);
        Destroy(GetComponent<Collider>());
    }
}

