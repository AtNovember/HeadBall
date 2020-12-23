using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    public static GameController instance;
    public Text txt_GoalsRight,txt_GoalsLeft, txt_timeMatch;
    public int number_GoalsRight, number_GoalsLeft;
    public bool isScore, EndMatch;
	public float timeMatch;
	private GameObject _ball, _AI, _Player;
    
    public void Awake(){
        if (instance == null){
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        timeMatch = 90;
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _Player = GameObject.FindGameObjectWithTag("Player");
        _AI = GameObject.FindGameObjectWithTag("AI");
		StartCoroutine(BeginMatch());
    }

    // Update is called once per frame
    void Update(){
        txt_GoalsLeft.text = number_GoalsLeft.ToString();
        txt_GoalsRight.text = number_GoalsRight.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }

    IEnumerator BeginMatch() {
	    while(true) {
		    yield return new WaitForSeconds(1f);
		    if (timeMatch > 0) {
			    timeMatch--;
			    if (isScore == true){
				    StartCoroutine(ContinueMatch());
			    }
		    } else {
			    EndMatch = true;
			    break;
		    }
	    }		
    }

    // public void ContinueMatch(){
	   //  StartCoroutine(WaitContinueMatch());
    // }
    
    // IEnumerator WaitContinueMatch() {
    IEnumerator ContinueMatch() {
	    yield return new WaitForSeconds(2f);
	    isScore = false;
	    if (EndMatch == false) {
		    _ball.transform.position = new Vector3(0, 0, 0);
		    _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		    _AI.transform.position = new Vector3(-5, 0, 0);
		    _Player.transform.position = new Vector3(5, 0, 0);
	    }
    }


}
