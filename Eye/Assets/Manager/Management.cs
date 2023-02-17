using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static byte HP;          //ĳ������ HP
    public static Vector3 CharPos;  //ĳ������ ��ġ��ǥ
    public static byte stage;       //ĳ������ �������� 1=1 2=2 3=3 4=BOSS


    int stage1_monster;                         //��������1 ���� ������
    [SerializeField] GameObject stage1_boss;    //��������1 �߰�����
    public static bool Isstage1_walll;          //��������1 �� T/F
    [SerializeField] GameObject stage1_wall;    //��������1 ��
    
    int stage2_monster;                         //��������2 ���� ������
    [SerializeField] GameObject stage2_boss;    //��������2 �߰�����
    public static bool Isstage2_walll;          //��������2 �� T/F
    [SerializeField] GameObject stage2_wall;    //��������2 ��

    int stage3_monster;                         //��������3 ���� ������
    [SerializeField] GameObject stage3_boss;    //��������3 �߰�����
    public static bool Isstage3_walll;          //��������3 �� T/F
    [SerializeField] GameObject stage3_wall;    //��������3 ��

    void Start()
    {
        HP = 100;               //�⺻ĳ(����) HP 100
        stage = 1;

        stage1_monster = 14;    //�������� 1 ���� ������
        stage2_monster = 16;    //�������� 2 ���� ������
        stage3_monster = 19;    //�������� 3 ���� ������

    }

    void Update()
    {
        Stagemaneger();
    }
    void Stagemaneger()
    {
        switch(stage)
        {
            case 1:
                if(stage1_monster < 0)
                {
                    Instantiate(stage1_boss);
                    if(Isstage1_walll == false)
                    {
                        Destroy(stage1_wall);
                        stage = 2;
                    }
                }
                break;
            case 2:
                if (stage2_monster < 0)
                {
                    Instantiate(stage2_boss);
                    if (Isstage2_walll == false)
                    {
                        Destroy(stage2_wall);
                        stage = 3;
                    }
                }
                break;
            case 3:
                if (stage3_monster < 0)
                {
                    Instantiate(stage3_boss);
                    if (Isstage3_walll == false)
                    {
                        Destroy(stage3_wall);
                        stage = 4;
                    }
                }
                break;
        }
    }
}