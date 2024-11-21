using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "FleeState(s)", menuName = "ScriptableObjects/State/FleeState")]

public class FleeState : State
{
    public string blendParameter; // parametro de mezcla para el Animator

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject reference = owner.GetComponent<TargetReference>().targets[0]; // oye owner dame tu componente de targetreference / tenemos el objetivo por el que nos vamos a mover
        Animator animator = owner.GetComponent<Animator>();

        Vector3 flee = (owner.transform.position - reference.transform.position).normalized; // vector hacia donde tiene que ir el enemigo (enemigo - player)
        navMeshAgent.SetDestination(owner.transform.position + (flee * 5)); // la posicion del owner(la tuya ahora) + la posicion a la que tienes que ir

        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //la velocidad maxima a la que puede ir es speed, lo dividimos para que quede entre 0 a 1

        return nextState;
    }

   
    
}
