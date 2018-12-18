using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : Interactable, IInteractable
{
    #region variables
    [SerializeField]
    Sprite message;
    GameObject hint;
    Image hintImage;
    GameObject postIt;
    Image postItSymbol;
    Rigidbody body;
    bool firstOpen = true;
    bool isOpen;
    bool pullBook;
    Text page1;
    Text page2;
    SpriteRenderer symbol;
    [SerializeField]
    Sprite nextBook;
    [SerializeField]
    GameObject keyCard;
    float posCounter = 0;
    float pullSpeed = 0.5f;
    string[] subjects = new string[] { "He", "She", "They", "Dogge", "Ferre", "A child", "The one who can't be named", "The friend", "A mysterious man", "A mysterious Woman", "A mysterious person", "God", "Their arch enemy", "Erkan" };
    string[] verbs = { "used", "saw", "ate", "caught", "threw", "hid", "fetched", "polished", "stepped on", "drew" };
    string[] aAn = { "a", "an", "the" };
    string[] adjectives = { "blue", "black", "yellow", "orange", "pink", "purple", "black", "grey", "green", "white", "red", "small", "big", "average sized", "jolly", "warm", "cold", "beautiful", "legendary", "evil" };
    string[] items = { "person", "apple", "boat", "rabbit", "animal", "friend", "sword", "piece of food", "item", "hat", "wand", "cloak", "silverware", "doorknob", "air guitar elemental" };
    string[][] words = new string[5][];
    #endregion


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        words = new string[][] { subjects, verbs, aAn, adjectives, items };
        hint = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject; //Gets the GameObject that contains the hint image.
        hintImage = hint.GetComponent<Image>();
        postIt = hint.transform.GetChild(2).gameObject;
        postItSymbol = postIt.transform.GetChild(0).GetComponent<Image>();
        page1 = hintImage.transform.GetChild(0).GetComponent<Text>();
        page2 = hintImage.transform.GetChild(1).GetComponent<Text>();
        symbol = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isOpen && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(0)))
        {
            hint.SetActive(false);
            isOpen = false;
            gm.State = Gamestate.Playing;
        }
        if (pullBook) //If the book contains the keycard, we want to pull the book out
        {
            if (keyCard != null)
            {
                posCounter += Time.deltaTime * pullSpeed;
                transform.Translate(Vector3.forward * Time.deltaTime * pullSpeed);
                if (posCounter >= 0.5f && keyCard != null)
                {
                    keyCard.SetActive(true);
                    keyCard.transform.position = transform.position;
                    keyCard = null;
                }
            }

            else
            {
                posCounter -= Time.deltaTime * pullSpeed;
                transform.Translate(Vector3.back * Time.deltaTime * pullSpeed);
                if (posCounter <= 0)
                {
                    posCounter = 0;
                    pullBook = false;
                    body.useGravity = true;
                    body.freezeRotation = false;
                    body.detectCollisions = true;
                }
            }
        }
    }

    public void Interact() //Opens the book if it does not contain a keycard, if it does, it drops the keycard instead.
    {
        if (keyCard == null)
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
            if (nextBook != null)
            {
                postIt.SetActive(true);
                postItSymbol.sprite = nextBook;
            }
            else
                postIt.SetActive(false);
            gm.State = Gamestate.Reading;
        }
        else
        {
            body = GetComponent<Rigidbody>();
            body.detectCollisions = false;
            body.freezeRotation = true;
            body.useGravity = false;
            pullBook = true;
        }

    }

    void GenerateText(Text t) //Generates a nonsenseical text for the book
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
                    if (!IsVowel(adjective[0]))
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

    bool IsVowel(char c) //returns true if the given char is a vowel
    {
        switch (c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
        }
        return false;
    }


}
