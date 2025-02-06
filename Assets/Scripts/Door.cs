using UnityEngine;

public class Door : MonoBehaviour, IInteracteble
{
    public static readonly int Open = Animator.StringToHash("Open");

    [SerializeField] private Animator _animator;

    public void Interact() =>
        _animator.SetTrigger(Open);
}

