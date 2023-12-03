using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [SerializeField] float speed = 30;
    [SerializeField] Rigidbody2D rb;
    public static event Action<string> onGoal;
    public override void OnStartServer()
    {
        //base.OnStartServer();
        rb.simulated = true;
        rb.velocity = Vector2.right * speed;          
    }
    [ServerCallback]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.GetComponent<Player>())
        {
            return;
        }

        
        float x = rb.velocity.x > 0
            ? -1
            : 1;
        float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * speed;
        
        
    }

    [ServerCallback]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Left":
            case "Right":
                onGoal?.Invoke(collision.tag);
                break;
        }
    }
}
