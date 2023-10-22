using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ItemData {
    public string id;
    public Sprite iconSprite;
    public AudioClip itemAudio;

    // description, etc?
}

public class ItemManager : MonoBehaviour
{
    public TMP_Text itemUI;
    public ItemData[] items;
    public List<Container> possibleContainers;
    public ItemData carriedItem;
    public AudioManager audioManager;
    public List<string> neededItem;
    //public TMP_Text interactDescription;
    int neededItemIndex = 0;
    //float DescTimeout = 0f;

    public bool carryingItem = false;

    public bool TryGrabItem(ItemData item) {
        if (carryingItem != false) {
            //interactDescription.text = "Already carrying something.";
            print("Already carrying something.");
            //DescTimeout = 2f;
            return false;
        }
        if (item.id == neededItem[neededItemIndex]) {
            carriedItem = item;
            print("Picked up " + item.id);
            carryingItem = true;
            itemUI.text = item.id;
            neededItemIndex++;
            return true;
        }
        print("Don't need this yet.");
        return false;

    }

    void DistributeItems() {
        var remaining = new List<Container>(possibleContainers);
        foreach (var item in items) {
            var containerIndex = Random.Range(0, remaining.Count);
            var location = remaining[containerIndex];
            location.contents = item;
            remaining.RemoveAt(containerIndex);
        }foreach (var item in remaining) {
            item.contents = null;
        }
       
    }

    public void UsedItem() {
        print("Used " + carriedItem.id + ".");
        audioManager.PlayItemSound(carriedItem.itemAudio);
        carriedItem = null;
        carryingItem= false;
        itemUI.text = "Empty";

    }

    private void Start() {
        DistributeItems();
    }
}
