using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class NewBehaviourScript : MonoBehaviour
{
    public float rayDistance = 0.5f;
    public float speed = 1.0f;
    public float thrust = 1.0f;

<<<<<<< HEAD
    private Rigidbody2D playerbody;
    private Vector2 moveVector;
    private bool OnGround = false;
    private void Awake()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }
=======
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
            Debug.Log("Ïðûæîê");
            playerbody.AddForce(playerbody.transform.up*thrust, ForceMode2D.Impulse);
        }

        HorizontalMove = Input.GetAxisRaw("Horizontal");

    }
>>>>>>> 6da1b9793580d99708be570f382bc9c4dfa56023
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerbody.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            OnGround = true;
        }
        else OnGround = false;
<<<<<<< HEAD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if ((horizontal > 0.1f || horizontal < -0.1f) && Mathf.Abs(playerbody.velocity.x) < 1.5f)
        {
            playerbody.AddForce(new Vector2(horizontal * speed, 0f), ForceMode2D.Impulse);
        }
        //Mathf.Abs(playerbody.velocity.y) < 0.005f
        if (vertical > 0.1f && OnGround) 
        {
            playerbody.AddForce(new Vector2(0f, vertical * thrust),ForceMode2D.Impulse);
        }
=======
        
        Vector2 targetVelocity = new Vector2(HorizontalMove * speed,playerbody.velocity.y);
        playerbody.velocity = targetVelocity;

        

>>>>>>> 6da1b9793580d99708be570f382bc9c4dfa56023
    }
}
