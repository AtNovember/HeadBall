using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour{
    public float rangerDenfece, speed;
    public Transform denfece;
    private GameObject _ball;
    private Rigidbody2D _rb_AI;
    public bool canShootAI, canHeadAI, grounded;
    public Transform checkGround;
    public LayerMask ground_layer;
    
    // Start is called before the first frame update
    void Start(){
        _ball = GameObject.FindGameObjectWithTag("Ball");
        // why can't we take AI with tag? what difference between GetComponent and GameObject.GetWithTag ?
        _rb_AI = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Move();
        if (canShootAI == true){
            Shoot();
        }

        if (canHeadAI == true){
            Jump();
        }
    }
    
    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
    }

    public void Move(){
        if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < rangerDenfece){
            if (_ball.transform.position.x > transform.position.x){
                _rb_AI.velocity = new Vector2(Time.deltaTime * speed, _rb_AI.velocity.y);
            }
            else{
                _rb_AI.velocity = new Vector2(-Time.deltaTime * speed, _rb_AI.velocity.y);
            }
        }
        else{
            if (transform.position.x > denfece.position.x){
                _rb_AI.velocity = new Vector2(-Time.deltaTime * speed, _rb_AI.velocity.y);
            }
            else{
                _rb_AI.velocity = new Vector2(0, _rb_AI.velocity.y);
            }
        }
    }

    public void Shoot(){
        if (canShootAI == true) {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 300));
        }
    }

    public void Jump(){
        if (grounded == true){
            _rb_AI.velocity = new Vector2(-Time.deltaTime * speed, 15);
        }
    }
}
