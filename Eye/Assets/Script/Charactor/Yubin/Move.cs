using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float maxSpeed;// 속도
    public float jumpPower; // 점프
    public Vector2 Range;
    bool isground;
    [SerializeField] Transform pos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Transform trans;
    int jumpcount =2; //2단점프
    int Jumpcnt;
    Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Jumpcnt = jumpcount;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //땅에 닿았는가?

        if(isground == false)
            anim.SetBool("isJump", true);

        if (isground == true && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 2
        {
            rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumpcnt--; //점프 카운트
        }
        if (isground)
        {
            Jumpcnt = jumpcount; //0이하로 내려가면 점프 불가
            anim.SetBool("isJump", false);

        }
        if (Input.GetButtonUp("Horizontal")) //속도제한
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

        if (Input.GetKeyDown("z"))//공격모션
        {
            anim.SetBool("isAttack", true);
        }
    }

    public void IdleAnimation_A()
    {
        anim.SetBool("isAttack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Range);
        Gizmos.DrawWireSphere(pos.position, radius);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //이동

        if (Input.GetAxisRaw("Horizontal")>0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }  

    }

}
