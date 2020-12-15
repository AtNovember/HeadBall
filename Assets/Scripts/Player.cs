using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float
        horialAxis,
        speed;
    private Rigidbody2D rb_player;

    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        rb_player.velocity = new Vector2(Time.deltaTime * speed * horialAxis, rb_player.velocity.y);
    }

    public void Move(int value)
    {
        horialAxis = value;
    }
}
