using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;//salud máxima del jugador
    public float CurrentHealth { get; private set; } //solo puede ser modificada dentro de la clase PlayerHealth.

    private void Start()
    {
        CurrentHealth = maxHealth; // inicia la salud del jugador
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;//resta la cantidad de daño
        if (CurrentHealth < 0) // verifica si la salud actual del jugador ha caído por debajo de cero.
        {
            CurrentHealth = 0;// la salud del jugador no se vuelva negativa y representa que el jugador está "muerto".
            //  muerte del jugador
            Debug.Log("El jugador ha muerto.");
        }

        //actualizar la barra de vida
        Debug.Log("Salud actual: " + CurrentHealth);
    }
}
