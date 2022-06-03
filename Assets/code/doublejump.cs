using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublejump : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator MonsterAnimator;
    BoxCollider2D bc;
    public LayerMask PlatformsLayerMask;
    bool canboublejump;
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = transform.GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        MonsterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >=-0.5f)
        {
            MonsterAnimator.SetInteger("Monsterstate", 3);
        }
        if(IsGrounded())
        {
            canboublejump = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (IsGrounded())
            {

                float jumpVelocity = 20f;
                rb.velocity = Vector2.up * jumpVelocity;
                
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    if (canboublejump)
                    {

                        float jumpVelocity = 20f;
                        rb.velocity = Vector2.up * jumpVelocity;
                        canboublejump = false;

                    }
                }
            }
        }
        
       
    }
    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2D= Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down,.1f, PlatformsLayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

}
