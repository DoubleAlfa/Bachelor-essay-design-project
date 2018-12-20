using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryText : MonoBehaviour
{

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Hint").GetComponent<Hint>().HintNumber < 6)
            gameObject.SetActive(false);
    }
}
