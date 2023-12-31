using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;

    [SerializeField, Range(0f, 360f)] float angle; 
    [SerializeField] float range;
    [SerializeField] Transform point;
    [SerializeField] LayerMask targetMask;

    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact() //상호작용 어댑터
    {
        Collider[] colliders = Physics.OverlapSphere(point.position, range, targetMask);
        foreach(Collider collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (collider.tag == "Tree")
            {
                interactable?.Interact();
                StartCoroutine(TreeShake());
                break;
            }

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
    IEnumerator TreeShake()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("IsShake");
        gameObject.GetComponent<PlayerInput>().enabled = true;
        yield return null;  
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