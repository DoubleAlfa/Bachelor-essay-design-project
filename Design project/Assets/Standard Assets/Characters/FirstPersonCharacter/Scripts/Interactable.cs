using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A superclass for everything interactable.
public class Interactable : MonoBehaviour
{

    protected Color startColor;
    protected Renderer rend;
    protected GameManager gm;
    public GameObject Gameobject
    {
        get { return gameObject; }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            startColor = rend.material.color;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    public virtual bool Highlight(bool active)
    {
        if (active)
            rend.material.color = Color.green;
        else
            rend.material.color = startColor;

        return true;
    }
}
