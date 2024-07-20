using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Player Animation Settings")]
    public Animator animator;

    public float rayDistance = 0.5f;
    public float speed = 1.0f;
    public float thrust = 1.0f;

    private float HorizontalMove;
    private Rigidbody2D playerbody;
    private bool OnGround = false;
    private void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            Debug.Log("Jump");
            playerbody.AddForce(playerbody.transform.up*thrust, ForceMode2D.Impulse);
        }
        
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        animator.SetFloat("Vert",Mathf.Abs(playerbody.velocity.y));
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerbody.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            OnGround = true;
        }
        else OnGround = false;
        
        Vector2 targetVelocity = new Vector2(HorizontalMove * speed,playerbody.velocity.y);
        playerbody.velocity = targetVelocity;

        

    }
}
