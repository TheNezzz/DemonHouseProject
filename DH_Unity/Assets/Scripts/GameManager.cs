using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameoverText;
    
    private void Awake() {
        gameoverText.text = "";
    }
    public void Victory() {
        Time.timeScale = 0;
        gameoverText.text = "You Win!";
    }

    public void Death() {
        Time.timeScale = 0;
        gameoverText.text = "You Died.";
    }
}
