using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemID { Salt, Candles, Matches, Doll}
    public ItemID item;

    private void Awake() {
        
    }
}
