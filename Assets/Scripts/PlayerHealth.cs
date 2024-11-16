using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3; // n�mero total de corazones
    public float heartHealth = 33.33f; // Salud por coraz�n (100 / 3)
    public int currentHearts; // Corazones restantes
    public Image[] hearts; // array para almacenar las im�genes de los corazones


    private void Start()
    {
        currentHearts = maxHearts; // Inicia con el n�mero m�ximo de corazones
        UpdateHearts();//actualizar la visualizaci�n de los corazones en la UI.

    }


    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].enabled = true; // activa la imagen del coraz�n si el jugador tiene ese coraz�n
            }
            else
            {
                hearts[i].enabled = false; // desactiva la imagen del coraz�n si el jugador no tiene ese coraz�n
            }
        }

        //  si el jugador ha perdido todos los corazones
        if (currentHearts <= 0)
        {
            GameManager.instance.PlayerDied(); // notifica al Game Manager que el jugador ha muerto
            ReStartScene(); // reinicia la escena
        }
    }

    public void ReStartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //obtiene el �ndice de la escena activa.
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage; //esta la cantidad de da�o a currentHearts.
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);
    }
}
