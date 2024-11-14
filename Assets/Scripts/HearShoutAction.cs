using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HearShoutAction(A)", menuName = "ScriptableObjects/Actions/HearShoutAction")]


public class HearShoutAction : Action
{
    public string animationClipToCheck; //almacena el nombre de un clip de animación que se desea verificar.
    public int targetIndex;
    public override bool Check(GameObject owner)
    {
        Animator animator = owner.GetComponent<TargetReference>().targets[targetIndex].GetComponent<Animator>(); //Se obtiene el componente Animator del objeto owner
        return animator.GetCurrentAnimatorStateInfo(0).IsTag(animationClipToCheck) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < animator.GetCurrentAnimatorStateInfo(0).length;
        //si la animacion animation clip to checj no ha cabado devuelve true , sino false
    }

    public override void DrawGizmos(GameObject owner)
    {
    }

    
}
