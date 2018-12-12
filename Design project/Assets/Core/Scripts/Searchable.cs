using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchable : Interactable, IInteractable
{
    Inventory inv;
    AudioSource audio;
    [SerializeField] AudioClip success, failure;
    [SerializeField] bool hasItem;
    [SerializeField] GameObject keyCard;

    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.GetChild(0).GetComponent<Inventory>();
        AudioSource audio = GetComponent<AudioSource>();
    }
    public GameObject Gameobject
    {
        get { return gameObject; }
    }

    public void Interact()
    {
        if (gameObject.tag == "Interactable")
        {
            audio.clip = success;
            audio.Play();
            inv.AddItem(keyCard);
        }
        else
        {
            audio.clip = failure;
            audio.Play();
        }


    }


}
