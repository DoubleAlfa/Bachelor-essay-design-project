using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    Sprite Icon
    {
        get;
    }
    bool Equip
    {
        get;
    }
}

public class Inventory : MonoBehaviour
{
    List<GameObject> inventory;
    Transform visualInventory;
    [SerializeField]
    Image image;

    public List<GameObject> PlayerInventory
    {
        get { return inventory; }
    }

	// Use this for initialization
	void Start ()
    {
        inventory = new List<GameObject>();
        visualInventory = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1);
	}
	

    public void AddItem(GameObject _newItem)
    {
        inventory.Add(_newItem);
        IItem _item = _newItem.GetComponent<IItem>();
        Image _image = Instantiate(image);
        _image.sprite = _item.Icon;
        _image.transform.SetParent(visualInventory);
        _image.transform.position = visualInventory.transform.position + Vector3.right * 100 *(visualInventory.childCount-1);
        if(_item.Equip)
        {
            _newItem.transform.SetParent(transform);
            _newItem.transform.position = transform.position;
            _newItem.transform.rotation = transform.rotation;
        }
    }
}
