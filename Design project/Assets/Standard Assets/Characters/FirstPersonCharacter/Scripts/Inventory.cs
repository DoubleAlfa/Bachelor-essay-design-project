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
    GameObject hands;

    public List<GameObject> PlayerInventory
    {
        get { return inventory; }
    }

    // Use this for initialization
    void Start()
    {
        inventory = new List<GameObject>();
        visualInventory = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Canvas"));
        DontDestroyOnLoad(gameObject);
    }


    public void AddItem(GameObject _newItem) //Adds an item to the inventory
    {
        if (hands == null)
            hands = GameObject.FindGameObjectWithTag("Hands");
        inventory.Add(_newItem);
        IItem _item = _newItem.GetComponent<IItem>();
        Image _image = Instantiate(image);
        _image.sprite = _item.Icon;
        _image.transform.SetParent(visualInventory);
        _image.transform.position = visualInventory.transform.position + Vector3.right * 100 * (visualInventory.childCount - 1);
        if (_item.Equip)
        {
            _newItem.transform.SetParent(hands.transform);
            _newItem.transform.position = hands.transform.position;
            _newItem.transform.rotation = hands.transform.rotation;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SetEquipment();
    }
    public void PrepareSceneChange()
    {
        foreach (GameObject item in inventory)
        {
            item.transform.SetParent(null);
            DontDestroyOnLoad(item);
        }
    }
    public void SetEquipment()
    {
        if (hands == null)
            hands = GameObject.FindGameObjectWithTag("Hands");
        for (int i = 0; i < inventory.Count; i++)
        {

            if (inventory[i].GetComponent<IItem>().Equip)
            {
                print("HEJ!");
                Flashlight f = inventory[i].GetComponent<Flashlight>();
                f.StartAfterScene();
                inventory[i].transform.SetParent(hands.transform);
                inventory[i].transform.position = hands.transform.position;
                inventory[i].transform.rotation = hands.transform.rotation;
                inventory[i].GetComponent<Flashlight>().Equiped = true;
            }
        }
    }
}
