using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Container : MonoBehaviour, IInteractable {
    public ItemData contents;
    public ItemManager manager;
    public TMP_Text containerDesc;
    AudioSource source;
    float DescTimeout = 0f;
    
    void Update() {
        if (DescTimeout > 0f) {
            DescTimeout -= Time.deltaTime;
            if (DescTimeout < 0f) {
                containerDesc.text = string.Empty;
                DescTimeout = 0f;
            }
        }
    }

    void Start() {
        source = GetComponent<AudioSource>();
        manager = FindObjectOfType<ItemManager>();
        containerDesc.text = string.Empty;
    }
    public void Interact() {
        print("Opened cabinet.");
        if (contents != null) {
            containerDesc.text = "Contains " + contents.id;
            DescTimeout = 2f;
            print("Contains " + contents.id);
            if (manager.TryGrabItem(contents)) {
                contents = null;
            }
        }
        else {
            print("Empty");
            containerDesc.text = "Empty";
            DescTimeout = 2f;
        }
        source.Play();
    }
    public string GetUIDescription() {
        return "";
    }
}
