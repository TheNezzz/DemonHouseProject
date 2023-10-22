using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource itemSounds;
    
    public void PlayItemSound(AudioClip clip) {
        itemSounds.PlayOneShot(clip);
    }

}
