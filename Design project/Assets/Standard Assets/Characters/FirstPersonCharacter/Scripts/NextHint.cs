using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHint : MonoBehaviour
{
    Hint h;
    [SerializeField]
    int hintNr;
    // Use this for initialization
    void Start()
    {
        h = FindObjectOfType<Hint>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            if (h.HintNumber == hintNr)
            {
                h.NextHint(hintNr);
                Destroy(this);
            }

        }

    }


}
