using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHint : MonoBehaviour {

    AudioSource a;
    Inventory i;
    Hint h;
    [SerializeField]
    AudioClip rememberFlashlight;
	// Use this for initialization
	void Start ()
    {
        a = gameObject.AddComponent<AudioSource>();
        a.clip = rememberFlashlight;
        i = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        h = GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !i.HasFlashlight() && !a.isPlaying && !h.GetComponent<AudioSource>().isPlaying)
            a.Play();
    }
}
