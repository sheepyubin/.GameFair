using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamManager : MonoBehaviour
{
    [SerializeField]
    Camera cam1;
    [SerializeField]
    Camera cam2;
    [SerializeField]
    GameObject Plyaer;

    private void OnTriggerEnter2D(Collider2D collision) //플레이어에게 닿았다면
    {
        if (collision.CompareTag("Stage1"))
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
        if (collision.CompareTag("Stage2"))
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
    }
}
