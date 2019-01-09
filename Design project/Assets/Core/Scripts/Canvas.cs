using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	if(GameObject.FindGameObjectsWithTag("Canvas").Length > 1)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
