using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Transform trans;
    Animator anim;

    public float MoveSpeed;     //�ӵ�
    public float jumpPower;     //����
    bool Isground;              //����
    const int jumpcount = 2;          //2������
    int Jumptemp;               //���� ī��Ʈ

    [SerializeField] Transform pos;     //����üũ����
    [SerializeField] float radius;      //����üũ������ ũ��(������)
    [SerializeField] LayerMask layer;   //�ٴ� ���̾��ũ

    [SerializeField] GameObject Skill;    //��ų ����Ʈ
    [SerializeField] Transform Skill_Pos;   //��ų ������ġ
    [SerializeField] GameObject Attack;    //��Ÿ ����ü
    [SerializeField] Transform Attack_Pos;   //��Ÿ ������ġ

    void Awake() //�⺻ ����
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Jumptemp = jumpcount;
    }

    public void Magician_SKill()    //��ų ����
    { Instantiate(Skill, Skill_Pos.position, transform.rotation); }

    public void Magician_Attack()    //��Ÿ ����ü ����
    { Instantiate(Attack,Attack_Pos.position, transform.rotation); }

    public void IdleAnimation_A()   //���þִ� �ʱ�ȭ
    { anim.SetBool("isAttack", false); }
    public void IdleAnimation_S()   //��ų�ִ� �ʱ�ȭ
    { anim.SetBool("isSkill", false); }
    private void OnDrawGizmos() //Pos �׸���
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, radius);
    }

    void Update()
    {
        Management.CharPos = transform.position;    //ĳ���� ��ǥ �������� �Ҵ�

        Isground = Physics2D.OverlapCircle(pos.position, radius, layer);    //���� Ȯ��

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

        if (Input.GetButtonUp("Horizontal")) //�ӵ�����
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

        if (Input.GetKeyDown("z"))
            anim.SetBool("isAttack", true);     //���ݸ��

        if (Input.GetKeyDown("x"))
            anim.SetBool("isSkill", true);      //��ų���

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //�̵�

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
