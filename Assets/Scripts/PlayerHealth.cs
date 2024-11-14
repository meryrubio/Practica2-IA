using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = maxHealth; // inicia la salud del jugador
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            //  muerte del jugador
            Debug.Log("El jugador ha muerto.");
        }

        //actualizar la barra de vida, si tienes una
        Debug.Log("Salud actual: " + CurrentHealth);
    }
}
