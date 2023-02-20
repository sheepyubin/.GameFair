using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    static public byte MaxHP;       //캐릭터의 최대 HP
    static public byte NOWHP;       //캐릭터의 현재 HP
    public static Vector3 CharPos;  //캐릭터의 위치좌표
    public static byte stage;       //캐릭터의 스테이지 1=1 2=2 3=3 4=BOSS


    int stage1_monster;                         //스테이지1 몬스터 마리수
    [SerializeField] GameObject stage1_boss;    //스테이지1 중간보스
    public static bool Isstage1_walll;          //스테이지1 벽 T/F
    [SerializeField] GameObject stage1_wall;    //스테이지1 벽
    
    int stage2_monster;                         //스테이지2 몬스터 마리수
    [SerializeField] GameObject stage2_boss;    //스테이지2 중간보스
    public static bool Isstage2_walll;          //스테이지2 벽 T/F
    [SerializeField] GameObject stage2_wall;    //스테이지2 벽

    int stage3_monster;                         //스테이지3 몬스터 마리수
    [SerializeField] GameObject stage3_boss;    //스테이지3 중간보스
    public static bool Isstage3_walll;          //스테이지3 벽 T/F
    [SerializeField] GameObject stage3_wall;    //스테이지3 벽

    void Start()
    {
        stage = 1;

        stage1_monster = 14;    //스테이지 1 몬스터 마리수
        stage2_monster = 16;    //스테이지 2 몬스터 마리수
        stage3_monster = 19;    //스테이지 3 몬스터 마리수

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