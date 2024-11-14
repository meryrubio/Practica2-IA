using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GetObjectAction(A)", menuName = "ScriptableObjects/Actions/GetObjectAction")]


public class GetObjectAction : Action
{
    public float radius = 20f; // Radio de búsqueda para recoger objetos
    private int prevCoinsCollected = 0; 

    public override bool Check(GameObject owner)
    {
        // para detectar objetos dentro del radio especificado
        Collider[] hitColliders = Physics.OverlapSphere(owner.transform.position,radius);

        // Obtenemos el objeto objetivo que el jugador puede recoger
        GameObject target = owner.GetComponent<TargetReference>().targets[0];

        if (target.GetComponent<PlayerMouvement_CC>().coinsCollected>0)
        {
            return true;
        }
        return false; // Si no coincide, no se puede recoger ningún objeto
    }



    public override void DrawGizmos(GameObject owner)
    {
        
    }

    
}
