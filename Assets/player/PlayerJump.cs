using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D playerbody;
    public float thrust = 1.0f;
    private Vector2 moveVector;

    private void Awake()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerbody.AddForce(new Vector2(0, thrust), ForceMode2D.Impulse);
        }
    }
}
