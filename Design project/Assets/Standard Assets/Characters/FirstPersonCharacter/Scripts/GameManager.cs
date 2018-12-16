using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public enum Gamestate { Playing, Paused, Reading }

public class GameManager : MonoBehaviour {

    Gamestate state = Gamestate.Playing;
    [SerializeField]
    string[] sceneNames;
    [SerializeField]
    int sceneCounter =0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            state = Gamestate.Playing;
        }
    }
    public Gamestate State
    {
        get { return state; }
        set { state = value; }
    }

    public void ToOtherFloor()
    {
        state = Gamestate.Paused;
        SceneManager.LoadScene(++sceneCounter);
    }
}






