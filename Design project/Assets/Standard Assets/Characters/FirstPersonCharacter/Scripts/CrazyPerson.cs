using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyPerson : Interactable, IInteractable {

    AudioSource audio;
    Hint hint;
    [SerializeField]
    AudioClip locked;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        audio = GetComponent<AudioSource>();
        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
            startColor = rend.material.color;
        }
        audio.clip = locked;
        hint = GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>();
    }

    public void Interact()
    {
        if( !hint.GetComponent<AudioSource>().isPlaying)
        audio.Play();
    }
}
