using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour, IInteractable
{

    [SerializeField]
    bool containsKeyCard;
    [SerializeField]
    Sprite message;
    GameObject hint;
    Image hintImage;
    bool firstOpen = true;
    bool isOpen;
    Text page1;
    Text page2;
    string[] subjects = new string[] { "He", "She", "They", "Dogge", "Ferre", "A child", "The one who can't be named", "The friend", "A mysterious man", "A mysterious Woman", "A mysterious person", "God", "Their arch enemy" };
    string[] verbs = { "used", "saw", "ate", "caught", "threw", "hid", "fetched", "polished", "stepped on" };
    string[] aAn = { "a", "an", "the" };
    string[] adjectives = { "blue", "black", "yellow", "orange", "pink", "purple", "black", "grey", "green", "white", "red", "small", "big", "average sized", "jolly", "warm", "cold", "beautiful", "legendary", "evil" };
    string[] items = { "person", "apple", "boat", "rabbit", "animal", "friend", "sword", "piece of food", "item", "hat", "wand", "cloak", "silverware", "doorknob" };
    string[][] words = new string[5][];

    public GameObject Gameobject
    {
        get { return gameObject; }
    }

    // Use this for initialization
    void Start()
    {
        words = new string[][] { subjects, verbs, aAn, adjectives, items };
        hint = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject; //Gets the GameObject that contains the hint image.
        hintImage = hint.GetComponent<Image>();
        page1 = hintImage.transform.GetChild(0).GetComponent<Text>();
        page2 = hintImage.transform.GetChild(1).GetComponent<Text>();
    }
    void Update()
    {
        if (isOpen && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(0)))
        {
            hint.SetActive(false);
            isOpen = false;
        }
    }

    public void Interact()
    {
        if (firstOpen)
        {
            GenerateText(page1);
            GenerateText(page2);
            firstOpen = false;
        }
        hint.SetActive(true);
        hintImage.sprite = message;
        isOpen = true;
    }

    void GenerateText(Text t)
    {
        string text = "";
        int rows = Random.Range(5, 10);
        for (int i = 0; i < rows; i++)
        {
            int peragraphScentences = Random.Range(1, 10);
            for (int j = 0; j < peragraphScentences; j++)
            {
                text += subjects[Random.Range(0, subjects.Length)] + " ";
                text += verbs[Random.Range(0, verbs.Length)] + " ";
                string adjective = adjectives[Random.Range(0, adjectives.Length)] + " ";
                int the = Random.Range(1, aAn.Length);
                if (the == 1)
                {
                    if (!isVowel(adjective[0]))
                        the = 0;
                }
                text += aAn[the] + " ";
                text += adjective;
                text += items[Random.Range(0, items.Length)] + ". ";
            }
            text += "\n\t";

        }
        t.text = text;
    }

    bool isVowel(char c)
    {
        switch(c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
                break;
        }
        return false;
    }
}
