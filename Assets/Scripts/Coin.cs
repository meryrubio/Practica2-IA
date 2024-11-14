using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 300, 0) * Time.deltaTime;
        transform.Rotate(rotation);
    }
    private void OnTriggerEnter(Collider other) // trigger porque lo quiero atravesar
    {
        if (other.gameObject.GetComponent<PlayerMouvement_CC>())
        {
            other.gameObject.GetComponent<PlayerMouvement_CC>().coinsCollected++;
            Destroy(gameObject);

        }
    }
}
