using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    public GameObject target;
    public GameObject to;
    [SerializeField]
    Camera cam1;
    [SerializeField]
    Camera cam2;
    private void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ��Ҵٸ�
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine());
        }
    }
    IEnumerator TeleportRoutine()
    {
        yield return null;
        target.transform.position = to.transform.position; //�ڷ���Ʈ
        cam1.enabled = false;
        cam2.enabled = true;
    }

}
