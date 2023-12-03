using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] float speed = 1500;
    [SerializeField] Rigidbody2D rb;

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        }
    }






}
