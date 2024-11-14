using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LookAction(A)", menuName = "ScriptableObjects/Actions/LookAction")]
public class LookAction : Action
{
    public float rotationSpeed = 5f; // Velocidad de rotaci�n
    public float visionAngle = 45f; // �ngulo de visi�n en grados
    public float visionDistance = 10f; // Distancia de visi�n

    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().targets[0]; //target, ubi del player

        if (target != null) //verifica si el objetivo existe, Si no hay un objetivo, no se realiza ninguna acci�n.
        {
            Vector3 directionToTarget = target.transform.position - owner.transform.position;  // calcular la direcci�n hacia el objetivo: Se calcula la direcci�n desde el personaje hacia el objetivo.
            directionToTarget.y = 0; //La componente Y se establece en 0 para que la rotaci�n solo ocurra en el plano horizontal
                                     // evitando que el personaje mire hacia arriba o hacia abajo.

            Vector3 forward = owner.transform.forward; //direcci�n hacia adelante

            //calcularr el �ngulo entre la direcci�n hacia el objetivo y la direcci�n hacia adelante
            float angle = Vector3.Angle(forward, directionToTarget);

            // verificar si el objetivo est� dentro del �ngulo de visi�n y la distancia
            return angle < visionAngle / 2 && directionToTarget.magnitude <= visionDistance;
        }
        return false; // si no hay objetivo, no se puede mirar
    }

    public override void DrawGizmos(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().targets[0];

        // para dibujar el cono de visi�n
        Gizmos.color = Color.green;
        Vector3 position = owner.transform.position;
        Vector3 forward = owner.transform.forward;

        // dibuja el cono //ESTO LO HE COPIADO
        for (float i = 0; i < visionDistance; i += 0.5f)
        {
            // calcula el radio en la distancia actual
            float radius = Mathf.Tan(visionAngle * Mathf.Deg2Rad / 2) * i;

            // dibuja un c�rculo en la posici�n actual
            Gizmos.DrawWireSphere(position + forward * i, radius);
        }


        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(position, target.transform.position); // dibuja una linea hacia el objetivo
        }
    }

    public void Execute(GameObject owner) //responsable de hacer que el personaje gire suavemente hacia un objetivo espec�fico 
    {
        GameObject target = owner.GetComponent<TargetReference>().targets[0];

        if (target != null)
        {
            // calcular la direcci�n hacia el objetivo
            Vector3 direction = target.transform.position - owner.transform.position;
            direction.y = 0; // Ignorar la componente Y

            // calcular la rotaci�n necesaria
            Quaternion targetRotation = Quaternion.LookRotation(direction); //Quaternion.LookRotation crea una rotaci�n que apunta en la direcci�n especificada.

            // rotar suavemente hacia la direcci�n del objetivo
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //se utiliza Quaternion.Slerp para interpolar suavemente entre la rotaci�n actual del personaje y la rotaci�n calculada hacia el objetivo//rotaci�n sea m�s natural 
        }
    }
}
