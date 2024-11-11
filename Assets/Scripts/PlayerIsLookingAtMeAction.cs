using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerIsLookingAtMeAction(A)", menuName = "ScriptableObjects/Actions/PlayerIsLookingAtMeAction")]


public class PlayerIsLookingAtMeAction : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;
        PlayerViewList viewListComponent = target.GetComponentInChildren<PlayerViewList>();
        List<GameObject> list = viewListComponent.viewList;

        foreach (GameObject gameobject in list)
        {
            if(owner == gameobject)
            {
                return true;

            }
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
       
    }

   
}
