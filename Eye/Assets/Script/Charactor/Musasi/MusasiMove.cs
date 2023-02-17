using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MusasiMove : MonoBehaviour
{
    public float maxSpeed;// 속도
    public float jumpPower; // 점프
    bool isground; //땅에 닿았는지 체크
    [SerializeField] Transform pos; //땅에 닿았는지 체크할때 쓰는거
    [SerializeField] float radius; // pos크기
    [SerializeField] LayerMask layer; //바닥 레이어 넣으면 된다
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Transform trans;
    int jumpcount = 2; //2단점프
    int Jumpcnt;
    Animator anim;

    //여기부터 스킬
    [SerializeField] GameObject Skill_1;//스킬 이펙트 프리팹 1
    [SerializeField] GameObject Skill_2; //스킬 이펙트 프리팹 2
    [SerializeField] Transform Skill_Pos; //스킬이 나올 위치
    Collider2D[] hit;
    [SerializeField] LayerMask Monster; //닿은 레이어 = 몬스터
    Vector3[] MonsterPos = new Vector3[20]; //몬스터 위치


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

        if (isground == false)
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

        if (Input.GetKeyDown("x")) //스킬모션
        {
            anim.SetBool("isSkill", true);
        }
    }

    public void IdleAnimation_W()
    {
        if (anim.GetBool("isJump") == true)
        {
            anim.SetBool("isWalk", false);
            Debug.Log("s");
        }
    }

    public void Musasi_SKill_1() //스킬 1타
    {
        Instantiate(Skill_1, Skill_Pos.position, transform.rotation);
    }

    public void Musasi_SKill_2() //스킬 2타
    {
        Instantiate(Skill_2, Skill_Pos.position, transform.rotation);
    }
    public void IdleAnimation_A()
    {
        anim.SetBool("isAttack", false);
    }

    public void IdleAnimation_S()
    {
        anim.SetBool("isSkill", false);
    }

    //private void OnDrawGizmos()
    //{
      //  Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position, Range);
        //Gizmos.DrawWireSphere(pos.position, radius);
    //}

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //이동

        if (Input.GetAxisRaw("Horizontal") > 0)
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
