using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritual : MonoBehaviour, IInteractable
{
    public bool ritualReady = false;
    public ItemManager manager;
    public GameManager gameManager;
    

    int usedItemIndex = 0;
    public List<GameObject> sprites = new List<GameObject>();

    private void Start() {
        manager = FindObjectOfType<ItemManager>();
        gameManager = FindObjectOfType<GameManager>();
        foreach(var sprite in sprites) {
            Renderer renderer = gameObject.GetComponent<Renderer>();
        }
    }
    public void Interact() {
        if (manager.carryingItem != false) {
            manager.UsedItem();
            sprites[usedItemIndex].gameObject.SetActive(true);
            usedItemIndex++;
            if (usedItemIndex >= sprites.Count) {
                gameManager.Victory();
            }
            
        }
    }

    
    public string GetUIDescription() {
        return "";
    }
}
