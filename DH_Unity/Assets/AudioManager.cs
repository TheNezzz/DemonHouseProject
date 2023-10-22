using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource itemSounds;
    public List<AudioClip> footsteps;
    public AudioSource footstepSource;
    //public AudioSource Ambient;
    //public List<AudioClip> ambientSounds;

    public void PlayItemSound(AudioClip clip) {
        itemSounds.PlayOneShot(clip);
    }

    //public void PlayAmbientSounds() {
    //    int index = Random.Range(0, ambientSounds.Count);
    //    Ambient.PlayOneShot(ambientSounds[index]);
    //}

    public void PlayFootstepSound() {
        int index = Random.Range(0, footsteps.Count);
        footstepSource.PlayOneShot(footsteps[index]);
    }

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.F1)) { 
        //    PlayFootstepSound();
        //}
    }
}
