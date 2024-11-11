using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GetObjectAction(A)", menuName = "ScriptableObjects/Actions/GetObjectAction")]


public class GetObjectAction : Action
{
    public float radius = 2f; // Radio de búsqueda para recoger objetos

    public override bool Check(GameObject owner)
    {
        // para detectar objetos dentro del radio especificado
        Collider[] hitColliders = Physics.OverlapSphere(owner.transform.position,radius);

        // Obtenemos el objeto objetivo que el jugador puede recoger
        GameObject target = owner.GetComponent<TargetReference>().target;

        foreach (Collider hit in hitColliders) // Recorremos todos los objetos detectados
        {
            if (hit.gameObject == target)
            {
                // si coincide con el objetivo, el jugador puede recogerlo
                CollectObject(target, owner);
                return true;
            }
        }
        return false; // Si no coincide, no se puede recoger ningún objeto
    }

    private void CollectObject(GameObject target, GameObject owner)
    {
        // para recoger el objeto
        PlayerMouvement_CC player = owner.GetComponent<PlayerMouvement_CC>();
    }

    public override void DrawGizmos(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    
}
