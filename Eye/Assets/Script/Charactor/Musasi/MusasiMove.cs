using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusasiMove : MonoBehaviour
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

    [SerializeField] GameObject Skill_1;    //스킬 이펙트 1
    [SerializeField] GameObject Skill_2;    //스킬 이펙트 2
    [SerializeField] Transform Skill_Pos;   //스킬 시작위치
    Collider2D[] hit;
    [SerializeField] LayerMask Monster;     //몬스터 탐색 레이어
    Vector3[] MonsterPos = new Vector3[20]; //몬스터 좌표

    void Awake() //기본 세팅
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Jumptemp = jumpcount;
    }

    public void Musasi_SKill_1()    //스킬 1타 생성
    { Instantiate(Skill_1, Skill_Pos.position, transform.rotation); }
    public void Musasi_SKill_2()    //스킬 2타 생성
    { Instantiate(Skill_2, Skill_Pos.position, transform.rotation); }

    public void IdleAnimation_A()   //어택애니 초기화
    { anim.SetBool("isAttack", false); }
    public void IdleAnimation_S()   //스킬애니 초기화
    { anim.SetBool("isSkill", false); }

    void Update()
    {
        Management.CharPos = transform.position;    //캐릭터 좌표 전역변수 할당

        Isground = Physics2D.OverlapCircle(pos.position, radius, layer);    //착지 확인

        if (Input.GetKeyDown("c") && Jumptemp > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Jumptemp--;
        }

        if(Isground)
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