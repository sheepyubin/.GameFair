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

    public float MoveSpeed;     //�ӵ�
    public float jumpPower;     //����
    bool isground;              //����
    const int jumpcount = 2;          //2������
    int Jumptemp;               //���� ī��Ʈ

    [SerializeField] Transform pos;     //����üũ����
    [SerializeField] float radius;      //����üũ������ ũ��(������)
    [SerializeField] LayerMask layer;   //�ٴ� ���̾��ũ


    [SerializeField] GameObject Skill;    //��ų ����Ʈ 1
    public Vector2 Range; //��ų ����
    Collider2D[] hit;
    [SerializeField] LayerMask Monster;     //���� Ž�� ���̾�
    Vector3[] MonsterPos = new Vector3[20]; //���� ��ǥ

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Jumptemp = jumpcount;
        anim = GetComponent<Animator>();
    }
    public void Thor_SKill() {
        hit = Physics2D.OverlapBoxAll(transform.position, Range, 0, Monster); //���Ϳ� ��Ҵ°�?
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

        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //���� ��Ҵ°�?

        if (isground == false)
            anim.SetBool("isJump", true);

        if (isground == true && Input.GetKeyDown("c") && Jumptemp > 0) //���� 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumptemp > 0) //���� 2
        {
            rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumptemp--; //���� ī��Ʈ
        }
        if (isground)
        {
            Jumptemp = jumpcount; //0���Ϸ� �������� ���� �Ұ�
            anim.SetBool("isJump", false);

        }
        if (Input.GetButtonUp("Horizontal")) //�ӵ�����
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);

        if (Input.GetKeyDown("z"))//���ݸ��
        {
            anim.SetBool("isAttack", true);
        }

        if (Input.GetKeyDown("x")) //��ų���
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
