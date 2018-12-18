﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable, IInteractable, IItem
{
    #region Variables
    [SerializeField]
    Sprite icon;
    Inventory inv;
    Hint h;
    [SerializeField]
    string toDoor;
    #endregion

    #region properties
    public bool Equip
    {
        get { return false; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public string ToDoor
    {
        get { return toDoor; }
    }
    #endregion

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        h = FindObjectOfType<Hint>();
    }


    public void Interact()
    {
        inv.AddItem(gameObject);
        h.NextHint();
        gameObject.SetActive(false);

    }
}
