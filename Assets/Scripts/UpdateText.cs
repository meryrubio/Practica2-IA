using System.Collections;
using System.Collections.Generic;
using TMPro; //avisar al c�digo de que vas a utlizar otro c�digo que esta en otra localizaci�n
using UnityEngine;

public class UpdateText : MonoBehaviour
{

    public GameManager.GameManagerVariables variable;


    private TMP_Text textComponent;
    private int auxscore; //variable auxiliar para saber si ha cambiado el valor

    // Start is called before the first frame update
    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {


        switch (variable) //
        {
            case GameManager.GameManagerVariables.TIME:
                textComponent.text = "Time: " + GameManager.instance.GetTime().ToString("0.00"); // se a�ade el tostring para que devuelva una representacion de la barra de tiempo con solo dos decimales
                break;
            case GameManager.GameManagerVariables.POINTS:
                if (auxscore != GameManager.instance.GetPoints()) // si auxscore es diferente a la actual empieza la corrutina, cuando cambie el nuemro empieza la corrutina
                {
                    textComponent.text = "POINTS: " + GameManager.instance.GetPoints().ToString();
                    StartCoroutine(FadeOut());
                    auxscore = GameManager.instance.GetPoints(); //actualizar lo que vale
                }
                break;
            default:
                break;

        }

    }
    IEnumerator FadeOut() // para que el objeto desaparezca poco a poco 
    {
        Color color = textComponent.color; // para guardarnos los parametros del color original de objeto 
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f) //para que el alpha se vaya reduciendo poco a poco.
        {
            color.a = alpha;
            textComponent.color = color;
            yield return new WaitForSeconds(0.005f); //devuelve el control a unity esos 0.005 segundos
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() // para que el objeto aparezca poco a poco 
    {
        Color color = textComponent.color; // para guardarnos los parametros del color original de objeto 
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f) //para que el alpha se vaya aumentando poco a poco.
        {
            color.a = alpha;
            textComponent.color = color;
            yield return new WaitForSeconds(0.005f); //devuelve el control a unity esos 0.005 segundos
        }

    }
}

