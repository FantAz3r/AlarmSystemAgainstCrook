using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private LayerMask _ignoreLayer;

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~_ignoreLayer))
        {
            if (Input.GetKeyDown(_interactionKey))
            {
                if (hit.collider.TryGetComponent(out IInteracteble iInteracteble))
                {
                    iInteracteble.Interact();
                }
            }
        }
    }
}
