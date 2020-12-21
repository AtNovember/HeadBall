using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject _player, _AI;
	public GameObject goals; 

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

        if (collision.gameObject.tag == "canHeadAI"){
            _AI.GetComponent<AI>().canHeadAI = true;
        }

		if (collision.gameObject.tag == "GoalsRight"){
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity); 
        }

		if (collision.gameObject.tag == "GoalsLeft"){
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity); 
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
        
        if (collision.gameObject.tag == "canHeadAI"){
            _AI.GetComponent<AI>().canHeadAI = false;
        }
    }
}
