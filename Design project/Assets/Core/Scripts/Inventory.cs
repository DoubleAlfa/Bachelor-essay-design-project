using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> inventory;

	// Use this for initialization
	void Start ()
    {
        inventory = new List<GameObject>();	
	}
	

    public void AddItem(GameObject newItem)
    {
        inventory.Add(newItem);

        IInteractable item = newItem.GetComponent<IInteractable>();
        if(item.Equip)
        {
            newItem.transform.SetParent(transform);
            newItem.transform.position = transform.position;
            newItem.transform.rotation = transform.rotation;
            newItem.transform.Rotate(Vector3.right * 90);
        }
    }
}
