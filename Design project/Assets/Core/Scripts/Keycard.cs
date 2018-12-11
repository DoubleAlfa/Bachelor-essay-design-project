using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable,IInteractable,IItem {

    [SerializeField]
    Sprite icon;
    Inventory inv;
    public GameObject Gameobject
    {
        get { return gameObject; }
    }
    public bool Equip
    {
        get { return false; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        inv = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetComponent<Inventory>();
	}
	

    public void Interact()
    {
        inv.AddItem(gameObject);
        gameObject.SetActive(false);
    }
}
