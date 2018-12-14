using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {


    AudioSource speech;
    [SerializeField]
    AudioClip[] hints;
    AudioClip activeHint;


	// Use this for initialization
	void Start ()
    {
        speech = gameObject.AddComponent<AudioSource>();

        activeHint = hints[0];
        speech.clip = activeHint;
	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            speech.clip = activeHint;
            speech.Play();
        }
    }


}
