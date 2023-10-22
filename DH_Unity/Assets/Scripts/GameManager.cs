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
    public Image endScreen;
    AudioSource source;
    bool bookOpen;
    private void Awake() {
        source = GetComponent<AudioSource>();   
        gameoverText.text = "";
        endScreen.gameObject.SetActive(false);
        book.gameObject.SetActive(false);
        bookOpen = false;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
    public void OpenBook() {
        if (bookOpen == true) {
            book.gameObject.SetActive(false);
            bookOpen = false;
        }
        else {
            book.gameObject.SetActive(true);
            bookOpen = true;
        }
    }

    public void Victory() {
        Time.timeScale = 0;
        gameoverText.text = "You Win!";
    }

    public void Death() {
        source.Play();
        Time.timeScale = 0;
        endScreen.gameObject.SetActive(true);
        gameoverText.text = "You Died.";
    }
}
