using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static byte HP;          //캐릭터의 HP
    public static bool LR;          //캐릭터의 좌,우
    public static Vector2 CharPos;  //캐릭터의 위치좌표
    float CurPos;                   //과거좌표
    float PrevPos;                  //현재좌표
    void Start()
    {
        HP = 100;
        CurPos = CharPos.x;
    }
    void LRcomparison()
    {
        if(CurPos< PrevPos)
        {

        }
    }
    void Update()
    {
        if()
    }
}