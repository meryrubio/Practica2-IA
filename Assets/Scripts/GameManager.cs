using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    //este script controla todo, funcionalidad y variabbles

    public static GameManager instance; // accesible a todo (variable estática) SINGLETON
    public enum GameManagerVariables { TIME, KILLS, POINTS }; // tipo enum (enumerar) para facilitar la lectura de código, time seria 0, points 1

    private float time;
    private int kills;
    private int points;

    private void Awake()
    {
        if (!instance)// si instance no tiene info
        {
            instance = this; //si isma llega a la fiesta y ve que no hay nadie guapo isma se queda en la fiesta / instance se asigna a este objeto
            DontDestroyOnLoad(gameObject);// para que no se destruya en la carga de escenas
        }
        else // si ya hay alguin mas guapo antes que isma / si instance tiene info
        {
            Destroy(gameObject); // isma se va / se destruye el gameobject, para que no haya dos o mas gms en el juego
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Detectar si se presiona la tecla ESCAPE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cargar la escena del menú principal
            SceneManager.LoadScene("MENU");
        }
        time += Time.deltaTime;
    }

    //getter (es para obtener el valor de esa variable)
    public float GetTime()
    {
        return time;
    }
    public void ResetTime() //para qyue el gamemanager reinicie el contador cada vez que se reinicia la escena.
    {
        time = 0;
    }

    public void IncreaseScore(int amount) // este metodo sirve para que los puntos puedan ir amuentando
    {
        kills += amount;
    }
    public int GetKills()
    {

        return kills;

    }

    //setter
    public void SetKills(int value)
    {
        kills = value;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        /* AudioManager.instance.ClearAudios();*/ // oye, audioManager, limpia todos los sonidos que estan sonando
    }

    public int GetPoints()
    {

        return points;

    }

    //setter
    public void SetPoints(int value)
    {
        points = value;
    }

    public void PlayerLostHeart()
    {
        // Lógica que se ejecuta cuando el jugador pierde un corazón
        Debug.Log("El jugador ha perdido un corazón.");
        // Aquí puedes agregar más lógica, como actualizar la UI o verificar si el jugador ha muerto
    }

    public void PlayerDied()
    {
        // Lógica que se ejecuta cuando el jugador muere
        Debug.Log("El jugador ha muerto.");
        // Aquí puedes agregar lógica para reiniciar el juego, mostrar un menú de muerte, etc.
    }

    public void ExitGame()
    {
        Debug.Log("EXIT!!");
        Application.Quit();// cierra la aplicación
    }


}

