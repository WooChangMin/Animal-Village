using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;

    [SerializeField, Range(0f, 360f)] float angle; 
    [SerializeField] float range;
    [SerializeField] Transform point;

    [SerializeField] LayerMask targetMask;


    public void Interact() //상호작용 어댑터
    {
        Collider[] colliders = Physics.OverlapSphere(point.position, range, targetMask);
        foreach(Collider collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            interactable?.Interact();
            /*Vector3 dirToTarget = (collider.transform.position - transform.position).normalized;
            if (Vector3.Dot(dirToTarget, Vector3.forward) < Mathf.Cos(angle* 0.5f* Mathf.Deg2Rad))
            {   

                Debug.Log("상호작용1");
                InteractAdaptor adaptor = collider.GetComponent<InteractAdaptor>();
            
                if (adaptor != null)
                {
                    Debug.Log("상호작용2");
                    adaptor.Interact(this);
                    break;
                }
            }*/
        }

    }
    private void OnInteract(InputValue value)
    {
        Interact();
    }

    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
    private void OnDrawGizmosSelected()
    {
        if (!debug)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(point.position, range);
    }
}