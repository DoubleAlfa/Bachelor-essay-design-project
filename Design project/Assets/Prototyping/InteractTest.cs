using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : MonoBehaviour, IInteractable
{
    float counter;
    bool spin;
    [SerializeField]
    Sprite icon;

    public bool Equip
    {
        get { return false; }
    }
    public GameObject Gameobject
    {
        get { return gameObject; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    void Update()
    {
        if(spin)
        {
            print("EYEYEYE");
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
            counter += Time.deltaTime * 50;
            if(counter >= 90)
            {
                spin = false;
                transform.Rotate(Vector3.down * (counter - 90));
                counter = 0;
            }
        }
    }
	public void Interact()
    {
        print("JAHAAA!");
        if(!spin)
        {
            spin = true;
        }
    }


}
