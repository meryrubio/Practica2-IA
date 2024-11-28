using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootState(s)", menuName = "ScriptableObjects/State/ShootState")]


public class ShootState : State
{
    public GameObject bulletPrefab;
    public float maxTime = 1;
    public float currentTime = 0;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        GameObject reference = owner.GetComponent<TargetReference>().targets[0];

        //nos mire
        owner.transform.LookAt(reference.transform);

        //dispara
        //(en el script de la bala, la dirección de la bala)
        //currentTime += Time.deltaTime;

        //if(currentTime > maxTime)
        //{
        //    GameObject bulletClone = Instantiate(bulletPrefab, owner.transform.position, Quaternion.identity);
        //    bulletClone.GetComponent<Bullet>().SetDirecTion(owner.transform.forward);//torreta
        //    bulletClone.GetComponent<Bullet>().SetDirecTion(reference.transform.forward - owner.transform.position);
        //    currentTime = 0;
        //}
       


        return nextState;

    }


}
