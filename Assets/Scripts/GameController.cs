using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    public static GameController instance;
    public Text txt_GoalsRight,txt_GoalsLeft ;
    public int number_GoalsRight, number_GoalsLeft;
    public bool isScore, EndMatch;
    
    public void Awake(){
        if (instance == null){
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        txt_GoalsLeft.text = number_GoalsLeft.ToString();
        txt_GoalsRight.text = number_GoalsRight.ToString();
    }
}
