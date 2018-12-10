using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public enum Gamestate { Playing, Paused, Reading }

public class GameManager : MonoBehaviour {

    Gamestate state = Gamestate.Playing;
    public Gamestate State
    {
        get { return state; }
        set { state = value; }
    }
}






