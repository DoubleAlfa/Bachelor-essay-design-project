using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : Interactable, IInteractable, IItem {
    Inventory inv;
    Hint h;
    string code = "Exit";
    [SerializeField]
    Sprite s;
    public bool Equip
    {
        get { return false; }
    }
    public string Code
    {
        get { return code; }
    }

    public Sprite Icon
    {
        get { return s; }
    }
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        h = GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>();
	}
    public void Interact()
    {
        inv.AddItem(gameObject);
        h.NextHint(6);
        gameObject.SetActive(false);
    }
}
