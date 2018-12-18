using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {


    AudioSource speech;
    [SerializeField]
    AudioClip[] hints;
    AudioClip activeHint;
    GameManager gm;
    int hint;

	// Use this for initialization
	void Start ()
    {
        speech = gameObject.AddComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        activeHint = hints[0];
        speech.clip = activeHint;
	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && gm.State == Gamestate.Playing) //Replays the last hint when 'Q' is pressed
        {
            speech.clip = activeHint;
            speech.Play();
        }
    }
    public void NextHint() //Gives a new hint to the player.
    {
        activeHint = hints[hint++];
        speech.clip = activeHint;
        speech.Play();
    }


}
