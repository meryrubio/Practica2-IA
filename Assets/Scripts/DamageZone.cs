using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class DamageZone : MonoBehaviour
{
    public float damageAmount = 10f; // cantidad de daño
    private float nextDamageTime = 0f; // Tiempo para el siguiente daño
    public float damageInterval = 1f; // Intervalo de tiempo entre daños


    public float radius = 8f;


    public void CreateZone(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up);
        GameObject target = owner.GetComponent<TargetReference>().targets[0]; //target, ubi del player

        foreach (RaycastHit hit in hits)
        {
            // verifica si el objeto golpeado tiene el componente Health
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null) //verifica  si se encontro un componente PlayerHealth
                                      //Si playerHealth no es null, significa que tiene un componente PlayerHealth
            {
                // aplica daño si ha pasado el intervalo
                if (Time.time >= nextDamageTime)
                {
                    playerHealth.TakeDamage(damageAmount);//restar la cantidad de daño de la salud del jugador
                    nextDamageTime = Time.time + damageInterval; // actualiza el tiempo para el siguiente daño
                }
            }
        }
        //// verifica si el objeto que entro tiene el componente PlayerHealth
        //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        //if (playerHealth != null)
        //{
        //    playerHealth.TakeDamage(damageAmount); // ataca
        //}


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
