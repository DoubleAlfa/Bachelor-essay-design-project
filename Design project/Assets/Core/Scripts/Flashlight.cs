using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour, IInteractable, IItem
{
    const bool equip = true;
    bool equiped = false;
    Inventory inv;
    [SerializeField]
    Sprite icon;
    Transform lights;
    Interact interact;

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
        lights = transform.GetChild(0);
        interact = FindObjectOfType<Interact>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (equiped && Input.GetKeyDown(KeyCode.E) && !interact.InteractIsActive) //Toggles the flashlight
            lights.gameObject.SetActive(!lights.gameObject.activeInHierarchy);
	}
    public void Interact()
    {
        inv.AddItem(gameObject);
        equiped = true;
    }
}
