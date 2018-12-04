using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour, IInteractable
{
    bool equip = true;
    Inventory inv;
    [SerializeField]
    Sprite icon;

    #region Properties
    public bool Equip
    {
        get{ return equip; }
    }

    public GameObject Gameobject
    {
        get { return gameObject; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }

    #endregion
    // Use this for initialization
    void Start ()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void Interact()
    {
        inv.AddItem(gameObject);
    }
}
