using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "DiegoWanderState(s)", menuName = "ScriptableObjects/State/DiegoWanderState")]


public class DiegoWanderState : State
{
    public float maxTime;
    public float radius;

    private float currentTime;

    public string blendParameter; // parametro de mezcla para el Animator

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        currentTime = Time.time;

        if(currentTime >= maxTime)
        {
            bool pointFound = false;
            do //utilizamos un do while por que queremos que se ejecute a menos una vez
            {
                Vector3 randompoint = owner.transform.position + Random.insideUnitSphere * radius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randompoint, out hit, radius, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                    pointFound = true;

                }
            }
            while (!pointFound);
            currentTime = 0;
        }

        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //la velocidad maxima a la que puede ir es speed, lo dividimos para que quede entre 0 a 1


        return nextState;
       
    }
    

    
}
