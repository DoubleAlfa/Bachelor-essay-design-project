using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public enum Gamestate { Playing, Paused, Reading }

public class GameManager : MonoBehaviour
{

    Gamestate state = Gamestate.Playing;
    [SerializeField]
    string[] sceneNames;
    [SerializeField]
    int sceneCounter = 0;
    GameObject player;
    Inventory inv;
    bool firstLoad = true;

    public bool FirstLoad
    {
        get { return firstLoad; }
    }

    public Gamestate State
    {
        get { return state; }
        set { state = value; }
    }

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
            Destroy(gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            state = Gamestate.Playing;
        }
    }

    public void ToOtherFloor()
    {
        inv.PrepareSceneChange();
        firstLoad = false;
        state = Gamestate.Paused;
        SceneManager.LoadScene(++sceneCounter %2);
        StartCoroutine(playNextFrame());
    }

    IEnumerator playNextFrame()
    {
        
        yield return new WaitForEndOfFrame();
        state = Gamestate.Playing;
        yield return new WaitForFixedUpdate();
        inv.SetEquipment();
    }
}






