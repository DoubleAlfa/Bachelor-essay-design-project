﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : Interactable, IInteractable, IItem
{
    const bool equip = true;
    bool equiped;
    float batteryCharge = 60; // 1 minut
    Inventory inv;
    [SerializeField]
    Sprite icon;
    [SerializeField]
    AudioClip[] sounds;
    Transform lights;
    Interact interact;
    AudioSource sfx;

    #region Properties
    public bool Equip
    {
        get { return equip; }
    }
    
    public bool Equiped
    {
        set { equiped = value; }
    }

    public Interact Int
    {
        set { interact = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }

    #endregion
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        lights = transform.GetChild(0);
        interact = FindObjectOfType<Interact>();
        sfx = GetComponent<AudioSource>();
        lights.gameObject.SetActive(false);
        batteryCharge *= Random.Range(2,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryCharge > 0) //if we have batteries left
        {
            //print(equiped + " " + !interact.InteractIsActive + " " + gm.State);
            if (equiped && Input.GetKeyDown(KeyCode.E) && !interact.InteractIsActive && gm.State == Gamestate.Playing) //Toggles the flashlight
            {
                print("HELLOOOO!");
                lights.gameObject.SetActive(!lights.gameObject.activeInHierarchy);
                if (lights.gameObject.activeInHierarchy)
                    sfx.clip = sounds[0];
                else
                    sfx.clip = sounds[1];
                sfx.Play();
            }
            if (lights.gameObject.activeInHierarchy) //Checks battery time
            {
                batteryCharge -= Time.deltaTime;
                if (batteryCharge <= 0)
                    lights.gameObject.SetActive(false);
            }
        }
    }
    public void Interact()
    {
        inv.AddItem(gameObject);
        lights.gameObject.SetActive(true);
        equiped = true;
    }
}
