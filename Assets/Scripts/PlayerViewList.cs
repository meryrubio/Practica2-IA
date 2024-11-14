using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerViewList : MonoBehaviour
{ //La clase se encarga de mantener una lista de objetos que están dentro de un área de visión,
  //utilizando colisionadores para detectar cuándo los objetos entran o salen de esa área.

    public List<GameObject> viewList; //Se declara una lista pública de GameObject llamada viewList.
                                      //Esta lista se utilizará para almacenar referencias a los objetos que entran en el área de visión del jugador.

    // Start is called before the first frame update
    void Start()
    {
        viewList = new List<GameObject>();//Aquí se inicializa viewList como una nueva lista vacía.
                                          //Esto asegura que la lista esté lista para usarse cuando el juego comience.
    }

    private void OnTriggerEnter(Collider other)
    {
        viewList.Add(other.gameObject); // other representa el colisionador que ha entrado.
                                        // se agrega el GameObject asociado con el colisionador other a la lista viewList.
                                        // Esto significa que todos los objetos que entran en el área de visión se registran en la lista.

    }

    private void OnTriggerExit(Collider other)
    {
        viewList.Remove(other.gameObject);//Aquí, se elimina el GameObject asociado con el colisionador other de la lista viewList.
                                          //Esto asegura que la lista solo contenga los objetos que actualmente están dentro del área de visión.
    }
}
