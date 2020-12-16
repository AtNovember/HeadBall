﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject _player, _AI;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _AI = GameObject.FindGameObjectWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            _player.GetComponent<Player>().canShoot = true;
        }
        
        if(collision.gameObject.tag == "canShootAI") {
            _AI.GetComponent<AI>().canShootAI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            _player.GetComponent<Player>().canShoot = false;
        }
        
        if(collision.gameObject.tag == "canShootAI") {
            _AI.GetComponent<AI>().canShootAI = false;
        }
    }
}
