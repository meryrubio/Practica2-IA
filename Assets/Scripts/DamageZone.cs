using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damageAmount = 10f; // cantidad de da�o

    private void OnTriggerEnter(Collider other)
    {
        // verifica si el objeto que entro tiene el componente PlayerHealth
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); // ataca
        }
    }
}
