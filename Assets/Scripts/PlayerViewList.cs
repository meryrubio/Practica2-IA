using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerViewList : MonoBehaviour
{ //La clase se encarga de mantener una lista de objetos que est�n dentro de un �rea de visi�n,
  //utilizando colisionadores para detectar cu�ndo los objetos entran o salen de esa �rea.

    public List<GameObject> viewList; //Se declara una lista p�blica de GameObject llamada viewList.
                                      //Esta lista se utilizar� para almacenar referencias a los objetos que entran en el �rea de visi�n del jugador.

    // Start is called before the first frame update
    void Start()
    {
        viewList = new List<GameObject>();//Aqu� se inicializa viewList como una nueva lista vac�a.
                                          //Esto asegura que la lista est� lista para usarse cuando el juego comience.
    }

    private void OnTriggerEnter(Collider other)
    {
        viewList.Add(other.gameObject); // other representa el colisionador que ha entrado.
                                        // se agrega el GameObject asociado con el colisionador other a la lista viewList.
                                        // Esto significa que todos los objetos que entran en el �rea de visi�n se registran en la lista.

    }

    private void OnTriggerExit(Collider other)
    {
        viewList.Remove(other.gameObject);//Aqu�, se elimina el GameObject asociado con el colisionador other de la lista viewList.
                                          //Esto asegura que la lista solo contenga los objetos que actualmente est�n dentro del �rea de visi�n.
    }
}
