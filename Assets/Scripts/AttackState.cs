using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState(s)", menuName = "ScriptableObjects/State/AttackState")]

public class AttackState : State
{
    public string blendParameter;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        return nextState;
    }

}
