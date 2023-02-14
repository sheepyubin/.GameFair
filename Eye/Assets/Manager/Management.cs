using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static byte HP;          //ĳ������ HP
    public static bool LR;          //ĳ������ ��(TRUE),��(FALSE)
    public static Vector2 CharPos;  //ĳ������ ��ġ��ǥ
    float CurPos;                   //������ǥ.X
    float PrevPos;                  //������ǥ.X

    int stage1_monster;
    bool Isstage1_boss;
    [SerializeField] GameObject stage1_boss;
    [SerializeField] GameObject stage1_wall;
    
    int stage2_monster;
    bool Isstage2_boss;
    [SerializeField] GameObject stage2_boss;
    [SerializeField] GameObject stage2_wall;

    int stahe3_monster;
    bool Isstahe3_boss;
    [SerializeField] GameObject stage3_boss;
    [SerializeField] GameObject stage3_wall;

    void Start()
    {
        CurPos = CharPos.x;
        HP = 100;
        LR = false;

        stage1_monster = 14;
        stage2_monster = 16;
        stahe3_monster = 19;

    }
    void Update()
    {
        LRcomparison();

    }
    void LRcomparison()
    {
        PrevPos = CharPos.x;

        if (CurPos < PrevPos) //������ X������ ������ X���� �۴ٸ�(�·� �̵�)
        { LR = true; }

        else if (CurPos > PrevPos) //������ X������ ������ X���� ũ�ٸ�(��� �̵�)
        { LR = false; }

        CurPos = PrevPos;
    }
}