using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExit : Interactable, IInteractable
{
    AudioSource audio;
    Hint hint;
    [SerializeField]
    AudioClip locked, getTheFile;

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
        hint = GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>();
    }

    public void Interact()
    {
        if (hint.HintNumber < 7)
        {
            if (!hint.GetComponent<AudioSource>().isPlaying)
            {
                audio.clip = getTheFile;
                audio.Play();
            }

        }
        else if (hint.HintNumber == 7)
        {
            hint.NextHint(7);
        }
        else
        {
            audio.clip = locked;
            audio.Play();
        }

    }
}
