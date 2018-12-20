using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>().HintNumber < 6)
            Destroy(gameObject);
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
            player.transform.Rotate(Vector3.up * 180);
        }
	}
	
	
}
