using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "ShoutState(s)", menuName = "ScriptableObjects/State/ShoutState")]
public class ShoutState : State
{
    public string blendParameter;

    public AudioClip shoutSound; // sonido de grito
    private AudioSource audioSource; // para reproducir el sonido
    private float currentTime = 0, maxTime = 0;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        Animator animator = owner.GetComponent<Animator>();
            animator.SetBool(blendParameter, true);

        currentTime += Time.deltaTime;
        if ( currentTime >= maxTime) //reproducir el sonido.
        {
            audioSource = AudioManager.instance.PlayAudio3D(shoutSound, "shoutSound", owner, 40, 60);
            maxTime = shoutSound.length;
            currentTime = 0;
        }



        return nextState;
    }


}
