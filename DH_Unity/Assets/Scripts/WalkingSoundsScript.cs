using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundsScript : MonoBehaviour
{
    public AudioClip[] steps;
    public AudioSource FootstepSource;
    
    public void PlayFootsteps() {
        int i = Random.Range(0, steps.Length);
        FootstepSource.PlayOneShot(steps[i]);
    }
}
