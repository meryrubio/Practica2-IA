using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerViewList : MonoBehaviour
{

    public List<GameObject> viewList;

    // Start is called before the first frame update
    void Start()
    {
        viewList = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        viewList.Add(other.gameObject); //añadimos todos los objetos que entran a la lista

    }

    private void OnTriggerExit(Collider other)
    {
        viewList.Remove(other.gameObject);
    }
}
