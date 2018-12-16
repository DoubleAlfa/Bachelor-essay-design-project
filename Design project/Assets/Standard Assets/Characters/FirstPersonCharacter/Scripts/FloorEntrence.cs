using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEntrence : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameManager _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!_gm.FirstLoad)
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            _player.transform.position = transform.position;
            _gm.State = Gamestate.Playing;
        }
        


    }


}
