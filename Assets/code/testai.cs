using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testai : MonoBehaviour
{
    Animator anim;
    public Transform Player;
    [SerializeField] float longdistance, closedistance, distancetoplayer, speedai;
    float InputX, InputY;
    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D bc;
    private Vector2 startPos;
    public Text textblood;
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Detectplayer();
    }
    void Detectplayer()
    {

        distancetoplayer = Vector3.Distance(Player.position, transform.position);
        if (distancetoplayer <= longdistance)
        {
            anim.SetInteger("zombieanim", 1);
            followplayer();
        }
        else
        {
            anim.SetInteger("zombieanim", 0);
        }
    }
    void followplayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speedai * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, longdistance);


        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, closedistance);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gamemanager.Instance.hp -= 100;
            textblood.text = Gamemanager.Instance.hp.ToString();

        }
    }
}
