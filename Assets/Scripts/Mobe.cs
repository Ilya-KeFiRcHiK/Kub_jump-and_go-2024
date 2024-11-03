using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
public class Mobe : MonoBehaviour
{
    [SerializeField] Transform target;
    float distance;
    UnityEngine.AI.NavMeshAgent myAgent;
    Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 10)
        {
            myAgent.enabled = false;
            myAnim.SetBool("Idle", true);
            myAnim.SetBool("Run", false);
            myAnim.SetBool("Attack", false);
        }

        if (distance <= 10 & distance > 1.5f)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.transform.position);
            myAnim.SetBool("Idle", false);
            myAnim.SetBool("Run", true);
            myAnim.SetBool("Attack", false);
        }

        if (distance <= 1.5f)
        {
            myAgent.enabled = false;
            myAnim.SetBool("Idle", false);
            myAnim.SetBool("Run", false);
            myAnim.SetBool("Attack", true);
        }
    }
}
