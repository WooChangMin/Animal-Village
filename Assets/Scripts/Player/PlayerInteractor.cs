using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;

    [SerializeField] float range;
    [SerializeField] Transform point;

    public void Interact()
    {
        Collider[] colliders = Physics.OverlapSphere(point.position, range);
        foreach(Collider collider in colliders)
        {
            InteractAdaptor adaptor = collider.GetComponent<InteractAdaptor>();
            if (adaptor != null)
            {
                adaptor.Interact(this);
                break;
            }
        }

    }
    private void OnInteract(InputValue value)
    {
        Interact();
    }

    private void OnDrawGizmosSelected()
    {
        if (!debug)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point.position, range);
    }
}