using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{


    AudioSource speech;
    [SerializeField]
    AudioClip[] hints;
    AudioClip activeHint;
    GameManager gm;
    int hint;

    public int HintNumber
    {
        get { return hint; }
    }
    // Use this for initialization
    void Start()
    {
        speech = gameObject.AddComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        activeHint = hints[0];
        speech.clip = activeHint;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gm.State == Gamestate.Playing) //Replays the last hint when 'Q' is pressed
        {
            speech.clip = activeHint;
            speech.Play();
        }
    }
    public void NextHint(int hintNr) //Gives a new hint to the player.
    {
        if (hintNr - hint == 0)
        {
            activeHint = hints[hint++];
            speech.clip = activeHint;
            speech.Play();
        }

    }


}
