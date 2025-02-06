using UnityEngine;

public class Door : MonoBehaviour, IInteracteble
{
    [SerializeField] private Animator _animator;

    public void Interact() => _animator.SetTrigger("Open");
}

