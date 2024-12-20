using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerIsLookingAtMeAction(A)", menuName = "ScriptableObjects/Actions/PlayerIsLookingAtMeAction")]


public class PlayerIsLookingAtMeAction : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().targets[0]; //representa a quien estamos mirando
        PlayerViewList viewListComponent = target.GetComponentInChildren<PlayerViewList>(); //el componente inchildren porque esta en un hijo
        List<GameObject> list = viewListComponent.viewList;// view list contiene todos los jugadores que el target est� mirando.

        foreach (GameObject gameobject in list) //indica que el jugador (representado por owner) est� siendo mirado por el target.
        {
            if(owner == gameobject)//si yo(owner) es igual al objeto devuelvo un true por que me mira)
            {
                return true;

            }
        }
        return false; //el jugador no est� siendo mirado
    }

    public override void DrawGizmos(GameObject owner)
    {
       
    }

   
}
