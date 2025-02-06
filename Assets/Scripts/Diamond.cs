using UnityEngine;

public class Diamond : MonoBehaviour, IInteracteble
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
