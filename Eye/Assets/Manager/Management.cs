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

        if (CurPos < PrevPos) //과거의 X값보다 현재의 X값이 작다면(좌로 이동)
        { LR = true; }

        else if (CurPos > PrevPos) //과거의 X값보다 현재의 X값이 크다면(우로 이동)
        { LR = false; }

        CurPos = PrevPos;
    }
}