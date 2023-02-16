using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThorMove : MonoBehaviour
{
    public float maxSpeed;// �ӵ�
    public float jumpPower; // ����
    public Vector2 Range; //��ų ����
    bool isground; //���� ��Ҵ��� üũ
    [SerializeField] Transform pos; //���� ��Ҵ��� üũ�Ҷ� ���°�
    [SerializeField] float radius; // posũ��
    [SerializeField] LayerMask layer; //�ٴ� ���̾� ������ �ȴ�
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Transform trans;
    int jumpcount = 2; //2������
    int Jumpcnt;
    Animator anim;

    //������� ��ų
    [SerializeField] GameObject Skill;//��ų ����Ʈ ������
    Collider2D[] hit;
    [SerializeField] LayerMask Monster; //���� ���̾� = ����
    Vector3[] MonsterPos = new Vector3[20]; //���� ��ġ


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Jumpcnt = jumpcount;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //���� ��Ҵ°�?

        if (isground == false)
            anim.SetBool("isJump", true);

        if (isground == true && Input.GetKeyDown("c") && Jumpcnt > 0) //���� 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumpcnt > 0) //���� 2
        {
            rigid.AddForce(Vector2.up * jumpPower * 0.8f, ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumpcnt--; //���� ī��Ʈ
        }
        if (isground)
        {
            Jumpcnt = jumpcount; //0���Ϸ� �������� ���� �Ұ�
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

    public void IdleAnimation_W()
    {
        if (anim.GetBool("isJump") == true)
        {
            anim.SetBool("isWalk", false);
            Debug.Log("s");
        }
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
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

    }

}
