using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float maxSpeed;// 속도
    public float jumpPower; // 점프
    public Vector2 Range;
    public LayerMask Monster;
    bool isground;
    [SerializeField] GameObject Skill;
    Collider2D[] hit;
    Vector3[] MonsterPos = new Vector3[20];
    [SerializeField] Transform pos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Transform trans;
    public int jumpcount;
    int Jumpcnt;
    int i = 0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Jumpcnt = jumpcount;

    }

    void Update()
    {
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //땅에 닿았는가?

        if (isground == true && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 2
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumpcnt--; //n단
        }
        if (isground)
        {
            Jumpcnt = jumpcount; //0이하로 내려가면 점프 불가
        }

        if (Input.GetButtonUp("Horizontal")) //속도제한
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Range);
        Gizmos.DrawWireSphere(pos.position, radius);
    }
    public void flipx()
    {
        spriteRenderer.flipX = false;
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //이동
    }
}
