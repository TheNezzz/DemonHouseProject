using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{   
    public ItemData contents;
    public ItemManager manager;

    

    
    
    void Update()
    {
    }
    
    void Start() {
      manager = FindObjectOfType<ItemManager>();
        
    }
    public void Interact() {
        print("Opened cabinet.");
        if (contents != null) {
            print("Contains " + contents.id);
            if (manager.TryGrabItem(contents)){      
                contents = null;
            } 
        }
        else print("Empty");
    }
    
        
    
    public string GetUIDescription() {
        return "";
    }
    


}
