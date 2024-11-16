using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3; // Número total de corazones
    public float heartHealth = 33.33f; // Salud por corazón (100 / 3)
    public int currentHearts; // Corazones restantes
    public Image[] hearts; // Array para almacenar las imágenes de los corazones


    private void Start()
    {
        currentHearts = maxHearts; // Inicia con el número máximo de corazones
        UpdateHearts();
    }


    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if( currentHearts <= 0 )
            {
                GameManager.instance.PlayerDied();
                ReStartScene();
            }
        }
    }

    public void ReStartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        currentHearts = Mathf.Clamp(currentHearts, 0, maxHearts);
    }
}
