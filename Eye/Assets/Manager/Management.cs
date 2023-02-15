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

    byte stage;

    int stage1_monster;                         //��������1 ���� ������
    [SerializeField] GameObject stage1_boss;    //��������1 �߰�����
    public static bool Isstage1_walll;          //��������1 �� T/F
    [SerializeField] GameObject stage1_wall;    //��������1 ��
    
    int stage2_monster;                         //��������2 ���� ������
    [SerializeField] GameObject stage2_boss;    //��������2 �߰�����
    public static bool Isstage2_walll;          //��������2 �� T/F
    [SerializeField] GameObject stage2_wall;    //��������2 ��

    int stahe3_monster;                         //��������3 ���� ������
    [SerializeField] GameObject stage3_boss;    //��������3 �߰�����
    public static bool Isstage3_walll;          //��������3 �� T/F
    [SerializeField] GameObject stage3_wall;    //��������3 ��

    void Start()
    {
        CurPos = CharPos.x;
        HP = 100;               //�⺻ĳ(����) HP 100
        LR = false;             //�⺻ ������
        stage = 1;

        stage1_monster = 14;    //�������� 1 ���� ������
        stage2_monster = 16;    //�������� 2 ���� ������
        stahe3_monster = 19;    //�������� 3 ���� ������

    }

    void Update()
    {
        LRcomparison();

    }

    void LRcomparison()
    {
        PrevPos = CharPos.x;

        if (CurPos < PrevPos)       //������ X������ ������ X���� �۴ٸ�(��)
        { LR = true; }

        else if (CurPos > PrevPos)  //������ X������ ������ X���� ũ�ٸ�(��)
        { LR = false; }

        CurPos = PrevPos;
    }

    void Stagemaneger()
    {
        switch(stage)
        {
            case 1:
                if(stage1_monster < 0)
                {
                    Instantiate(stage1_boss);
                }
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}