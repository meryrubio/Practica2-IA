using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "PatrolState(s)", menuName = "ScriptableObjects/State/PatrolState")]

public class PatrolState : State
{
    public Vector3[] wayPoints;
    public int currentPoint;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent nagent = owner.GetComponent<NavMeshAgent>();

        if (nagent.remainingDistance <= nagent.stoppingDistance)
        {
            currentPoint++;
            currentPoint %= wayPoints.Length;//esoigual que hacer in if:     -> el % nos devielve el resto(division)
            //if (currentPoint >= wayPoints.Length)
            //{
            //    currentPoint = 0;
            //}
        }

        nagent.SetDestination(wayPoints[currentPoint]);

        return nextState;
    }

}
