using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHint : MonoBehaviour {


    Hint h;
	// Use this for initialization
	void Start ()
    {
        h = FindObjectOfType<Hint>();
	}

    void OnTriggerEnter(Collider other)
    {
        h.NextHint();
        Destroy(this);
    }


}
