using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static byte HP;          //캐릭터의 HP
    public static bool LR;          //캐릭터의 좌(TRUE),우(FALSE)
    public static Vector2 CharPos;  //캐릭터의 위치좌표
    float CurPos;                   //과거좌표.X
    float PrevPos;                  //현재좌표.X

    byte stage;

    int stage1_monster; //스테이지1 몬스터 마리수
    bool Isstage1_boss; //스테이지1 중간보스
    [SerializeField] GameObject stage1_boss;    //스테이지1 보스
    [SerializeField] GameObject stage1_wall;    //스테이지1 벽
    
    int stage2_monster; //스테이지2 몬스터 마리수
    bool Isstage2_boss; //스테이지2 중간보스
    [SerializeField] GameObject stage2_boss;    //스테이지2 보스
    [SerializeField] GameObject stage2_wall;    //스테이지2 벽

    int stahe3_monster; //스테이지3 몬스터 마리수
    bool Isstahe3_boss; //스테이지3 중간보스
    [SerializeField] GameObject stage3_boss;    //스테이지3 보스
    [SerializeField] GameObject stage3_wall;    //스테이지3 벽

    void Start()
    {
        CurPos = CharPos.x;
        HP = 100;               //기본캐(유빈) HP 100
        LR = false;             //기본 오른쪽
        stage = 1;

        stage1_monster = 14;    //스테이지 1 몬스터 마리수
        stage2_monster = 16;    //스테이지 2 몬스터 마리수
        stahe3_monster = 19;    //스테이지 3 몬스터 마리수

    }

    void Update()
    {
        LRcomparison();

    }

    void LRcomparison()
    {
        PrevPos = CharPos.x;

        if (CurPos < PrevPos)       //과거의 X값보다 현재의 X값이 작다면(좌)
        { LR = true; }

        else if (CurPos > PrevPos)  //과거의 X값보다 현재의 X값이 크다면(우)
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
                    invoke()
                }
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}