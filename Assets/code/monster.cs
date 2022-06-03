using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    Animator MonsterAnimator;
    Rigidbody2D rb;
    float InputX, InputY;
    public float speed;
    public float rollingspeed;
    bool checkJump;
    SpriteRenderer sr;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        MonsterAnimator = GetComponent<Animator>();
    }


    void Update()
    {

        if (InputX == 0)
        {
            MonsterAnimator.SetInteger("Monsterstate", 0);
        }

        if (Gamemanager.Instance.hp == 0)
        {
            MonsterAnimator.SetInteger("Monsterstate", 5);
        }
        run();
        rolling();
        flip();
        sit();
        walk();
        gameOver();

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(InputX, rb.velocity.y, InputY);
        MonsterAnimator.SetInteger("Monsterstate", 1);
    }
    void jump()
    {
        rb.AddForce(transform.up * Gamemanager.Instance.jumpforce);
        MonsterAnimator.SetInteger("Monsterstate", 3);
    }
    void flip()
    {
        if (InputX < 0)
        {
            sr.flipX = true;
        }
        if (InputX > 0)
        {
            sr.flipX = false;
        }
    }
    void run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            rb.velocity = new Vector3(InputX * Gamemanager.Instance.speedRun, rb.velocity.y, InputY * Gamemanager.Instance.speedRun);
            MonsterAnimator.SetInteger("Monsterstate", 2);
        }
    }
    void rolling()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.velocity = new Vector3(InputX * Gamemanager.Instance.rollingspeed, rb.velocity.y, InputY * Gamemanager.Instance.rollingspeed);
            MonsterAnimator.SetInteger("Monsterstate", 4);
        }
    }
    void sit()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {

            MonsterAnimator.SetInteger("Monsterstate", 6);

        }
    }
    void gameOver()
    {
        if (Gamemanager.Instance.hp <= 0)
        {
            InputX = Input.GetAxis("Horizontal") * 0;
            InputY = Input.GetAxis("Vertical") * 0;
            MonsterAnimator.SetInteger("Monsterstate", 5);
        }
    }
    void walk()
    {
        InputX = Input.GetAxis("Horizontal") * Gamemanager.Instance.speedWalk;
        InputY = Input.GetAxis("Vertical") * Gamemanager.Instance.speedWalk;
    }
}
