using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RobinMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Transform trans;
    Animator anim;

    public float MoveSpeed;     //속도
    public float jumpPower;     //점프
    bool Isground;              //착지
    const int jumpcount = 2;          //2단점프
    int Jumptemp;               //점프 카운트

    [SerializeField] Transform pos;     //착지체크범위
    [SerializeField] float radius;      //착지체크범위의 크기(반지름)
    [SerializeField] LayerMask layer;   //바닥 레이어마스크
    
    [SerializeField] LayerMask Monster;     //몬스터 탐색
    [SerializeField] GameObject Skill;    //스킬 이펙트
    [SerializeField] Transform Skill_Pos;   //스킬 시작위치
    [SerializeField] GameObject Attack;    //평타 투사체
    [SerializeField] Transform Attack_Pos;   //평타 시작위치

    void Awake() //기본 세팅
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Jumptemp = jumpcount;
    }

    public void Robin_SKill()    //스킬 생성
    {
        Instantiate(Skill, Skill_Pos.position, transform.rotation);
    }

    public void Robin_Attack()    //평타 투사체 생성
    { Instantiate(Attack, Attack_Pos.position, transform.rotation); }

    public void IdleAnimation_A()   //어택애니 초기화
    { anim.SetBool("isAttack", false); }
    public void IdleAnimation_S()   //스킬애니 초기화
    { anim.SetBool("isSkill", false); }
    private void OnDrawGizmos() //Pos 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, radius);
    }

    void Update()
    {
        Management.CharPos = transform.position;    //캐릭터 좌표 전역변수 할당

        Isground = Physics2D.OverlapCircle(pos.position, radius, layer);    //착지 확인

        if (Input.GetKeyDown("c") && Jumptemp > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Jumptemp--;
        }

        if (Isground)
        {
            Jumptemp = jumpcount;
            anim.SetBool("isJump", false);
        }
        else
            anim.SetBool("isJump", true);

        if (Input.GetButtonUp("Horizontal")) //속도제한
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

        if (Input.GetKeyDown("z"))
            anim.SetBool("isAttack", true);     //공격모션

        if (Input.GetKeyDown("x"))
            anim.SetBool("isSkill", true);      //스킬모션

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
