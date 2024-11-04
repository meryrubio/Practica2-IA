using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
[CreateAssetMenu(fileName = "WanderState(s)", menuName = "ScriptableObjects/State/WanderState")]

public class WanderState : State
{
    private float timer; //temporizador
    public float wanderTimer = 5f; // tiempo entre cambios de dirección

    private Vector3 wanderPoint;

    public string blendParameter; // parametro de mezcla para el Animator

    public  void Start()
    {
        timer = wanderTimer; // inicia el temporizador
        SetNewWanderPoint(); // establece un punto de deambular inicial
    }
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); //owner tiene el componente de navmeshagent / nos podemos mover
        Animator animator = owner.GetComponent<Animator>();


        timer += Time.deltaTime;// actualiza el temporizador
        if (timer >= wanderTimer) //si el temporizador ha alcanzado el tiempo de deambular, establece un nuevo punto
        {
            SetNewWanderPoint();
            timer = 0; // reinicia el temporizador
        }

        navMeshAgent.SetDestination(wanderPoint);
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //la velocidad maxima a la que puede ir es speed, lo dividimos para que quede entre 0 a 1

        return nextState;
    }
    private void SetNewWanderPoint()
    {
        //Vector3 randomDirection =

        //randomDirection += transform.position; //en relación a la posición actual

        //proyectar el nuevo punto en el NavMesh??????
    }



}
