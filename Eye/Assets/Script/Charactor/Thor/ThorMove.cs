using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThorMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Transform trans;
    Animator anim;

    public float MoveSpeed;     //속도
    public float jumpPower;     //점프
    bool isground;              //착지
    const int jumpcount = 2;          //2단점프
    int Jumptemp;               //점프 카운트

    [SerializeField] Transform pos;     //착지체크범위
    [SerializeField] float radius;      //착지체크범위의 크기(반지름)
    [SerializeField] LayerMask layer;   //바닥 레이어마스크


    [SerializeField] GameObject Skill;    //스킬 이펙트 1
    public Vector2 Range; //스킬 범위
    Collider2D[] hit;
    [SerializeField] LayerMask Monster;     //몬스터 탐색 레이어
    Vector3[] MonsterPos = new Vector3[20]; //몬스터 좌표

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Jumptemp = jumpcount;
        anim = GetComponent<Animator>();
    }
    public void Thor_SKill() {
        hit = Physics2D.OverlapBoxAll(transform.position, Range, 0, Monster); //몬스터에 닿았는가?
        for (int i = 0; i < hit.Length; i++)
        {
            MonsterPos[i] = hit[i].transform.position;
            Destroy(Instantiate(Skill, MonsterPos[i], Quaternion.identity), 0.4f);
        }
    }

    public void IdleAnimation_A()
    {
        anim.SetBool("isAttack", false);
    }

    public void IdleAnimation_S()
    {
        anim.SetBool("isSkill", false);
    }

    void Update()
    {
        Management.CharPos = transform.position;

        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //땅에 닿았는가?

        if (isground == false)
            anim.SetBool("isJump", true);

        if (isground == true && Input.GetKeyDown("c") && Jumptemp > 0) //점프 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumptemp > 0) //점프 2
        {
            rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumptemp--; //점프 카운트
        }
        if (isground)
        {
            Jumptemp = jumpcount; //0이하로 내려가면 점프 불가
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

        if (Input.GetKeyDown("x")) //스킬모션
        {
            anim.SetBool("isSkill", true);
        }
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

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(MoveSpeed, rigid.velocity.y);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(MoveSpeed * (-1), rigid.velocity.y);
        }

    }

}
