using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public static byte HP;          //ĳ������ HP
    public static bool LR;          //ĳ������ ��,��
    public static Vector2 CharPos;  //ĳ������ ��ġ��ǥ
    float CurPos;                   //������ǥ
    float PrevPos;                  //������ǥ
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