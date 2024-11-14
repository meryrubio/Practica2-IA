using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName = "WanderState(s)", menuName = "ScriptableObjects/State/WanderState")]

public class WanderState : State
{
    private float timer; //temporizador
    public float wanderTimer = 2f; // tiempo entre cambios de dirección
    float wanderRadius; // Radio de deambulación


    public string blendParameter; // parametro de mezcla para el Animator

  
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); //owner tiene el componente de navmeshagent / nos podemos mover
        Animator animator = owner.GetComponent<Animator>();


        timer += Time.deltaTime;// actualiza el temporizador
        if (timer >= wanderTimer) //si el temporizador ha alcanzado el tiempo de deambular, establece un nuevo punto
        {
            Wander(navMeshAgent);
            timer = 0; // reinicia el temporizador
        }

        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //la velocidad maxima a la que puede ir es speed, lo dividimos para que quede entre 0 a 1

        return nextState;
    }
    private void Wander(NavMeshAgent navMeshAgent)
    {
        //generamos una nueva posicion aleatoria dentro del radio de deambulacion
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += navMeshAgent.transform.position;//nueva posicion en relacion con la posicion actual

        //establecer el destino de la nueva posicion
        NavMeshHit hit; //el punto más cercano en el NavMesh que se encuentra en la dirección aleatoria generada.
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas)) //Este método intenta encontrar la posición más cercana en el NavMesh a la randomDirection generada.
                                                                                              //out hit: Si se encuentra un punto en el NavMesh, se almacena en la variable hit.
                                                                                              //NavMesh.AllAreas: Especifica que se debe considerar todas las áreas del NavMesh al buscar una posición.
        {
            navMeshAgent.SetDestination(hit.position);//establece el destino y el agente se mueva hacia esa nueva posición aleatoria.
        }

    }



}
