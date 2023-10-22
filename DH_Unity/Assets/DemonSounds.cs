using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class DemonSounds : MonoBehaviour {

    public AudioSource source;
    public float minWaitBetweenPlays = 2f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update() {
        if (!source.isPlaying) {
            if (waitTimeCountdown < 0f) {
                source.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
