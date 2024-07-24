using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform GroundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask wall;
    [SerializeField] Rigidbody2D playerbody;
    [Header("Player Animation Settings")]
    public Animator animator;

    public float speed = 1.0f;
    public float thrust = 1.0f;
    public float shift = 1.0f;
    public float wallSlideSpeed = 1.0f;

    private bool wallSlide;
    private bool doublejump;
    private bool facingRight = true;
    private float totalSpeed;
    private float HorizontalMove;
    private void Update()
    {
        if (HorizontalMove < 0 && facingRight)
        {
            Flip();
        }
        if (HorizontalMove > 0 && !facingRight)
        {
            Flip(); 
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnGround())
            {
                playerbody.velocity = new Vector2(playerbody.velocity.x, thrust);
                doublejump = false;
                Debug.Log("ïðûæîê1");
            }
            
            else if (!doublejump)
            {
                doublejump = true;
                playerbody.velocity = new Vector2(playerbody.velocity.x, thrust);
                Debug.Log("ïðûæîê2");
            }
        }
        if ((Input.GetKeyUp(KeyCode.Space))&&(playerbody.velocity.y > 0f)) 
        {
            playerbody.velocity = new Vector2(playerbody.velocity.x, playerbody.velocity.y * 0.5f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalSpeed = shift + speed;
        }
        else totalSpeed = speed;

        WallSlide();

        HorizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        animator.SetFloat("Vert",Mathf.Abs(playerbody.velocity.y));
    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * totalSpeed,playerbody.velocity.y);
        playerbody.velocity = targetVelocity;

    }
    private bool OnWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wall);
    }
    private bool OnGround()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }
    private void WallSlide()
    {
        if (!OnGround() && OnWall() && HorizontalMove != 0)
        {
            wallSlide = true;
            playerbody.velocity = new Vector2(playerbody.velocity.x, Mathf.Clamp(playerbody.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else wallSlide = false;
    }
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scale =  transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
