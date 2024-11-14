using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "AttackState(s)", menuName = "ScriptableObjects/State/AttackState")]

public class AttackState : State
{
    public string blendParameter;

    public float attackCooldown = 1f; // tiempo entre ataques
    private float lastAttackTime = 0f; // tiempo desde el último ataque

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);


        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); //owner tiene el componente de navmeshagent / nos podemos mover
        GameObject target = owner.GetComponent<TargetReference>().targets[0]; // oye owner dame tu componente de targetreference / tenemos el objetivo por el que nos vamos a mover
        Animator animator = owner.GetComponent<Animator>();
            animator.SetBool(blendParameter, true);

        // comprobamos si puede atacar
        if (Time.time >= lastAttackTime + attackCooldown) //si ha pasado el tiempo de cooldown desde el último ataque,
                                                          //se activa la animación de ataque y se actualiza el tiempo del último ataque
        {
            // animación de ataque
            lastAttackTime = Time.time; // actualiza el tiempo del último ataque
        }


        return nextState;
    }

}
