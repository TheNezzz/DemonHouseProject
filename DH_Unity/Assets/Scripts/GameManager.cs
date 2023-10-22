using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameoverText;
    public List<Sprite> itemIcons;
    public Image book;
    public Image hand;
    bool bookOpen;
    private void Awake() {
        gameoverText.text = "";
        book.gameObject.SetActive(false);
        bookOpen = false;
    }
    public void OpenBook() {
        if (bookOpen == true) {
            book.gameObject.SetActive(false);
            bookOpen = false;
        }
        else book.gameObject.SetActive(true);
        bookOpen = true;
    }
    public void CloseBook() {
        book.gameObject.SetActive(false);
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
