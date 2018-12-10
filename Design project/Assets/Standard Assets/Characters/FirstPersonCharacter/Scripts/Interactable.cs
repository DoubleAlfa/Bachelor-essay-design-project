using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    
    protected Color startColor;
    protected Renderer rend;
    protected GameManager gm;

    // Use this for initialization
    protected virtual void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    public virtual void Highlight(bool active)
    {
        if (active)
            rend.material.color = Color.green;
        else
            rend.material.color = startColor;
    }
}
