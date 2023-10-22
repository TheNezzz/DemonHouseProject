using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemData {
    public string id;
    public Sprite iconSprite;
    public AudioClip itemAudio;
    // description, etc?
}

public class ItemManager : MonoBehaviour
{
    public ItemData[] items;
    public List<Container> possibleContainers;
    public ItemData carriedItem;

    public List<string> neededItem;
    int neededItemIndex = 0;

    public bool carryingItem = false;

    public bool TryGrabItem(ItemData item) {
        if (carryingItem != false) {
            print("Already carrying something.");
            return false;
        }
        if (item.id == neededItem[neededItemIndex]) {
            carriedItem = item;
            print("Picked up " + item.id);
            carryingItem = true;
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
        carriedItem = null;
        carryingItem= false;

    }

    private void Start() {
        DistributeItems();
        
    }
}
