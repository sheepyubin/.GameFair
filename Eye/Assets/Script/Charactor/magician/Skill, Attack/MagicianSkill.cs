using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianSkill : MonoBehaviour
{
    public float speed; //��ų ���ǵ�
    void Start()
    {
        Invoke("DestroySkill", 0.4f);
    }

    void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(transform.right * speed * Time.deltaTime); //------->
        else
            transform.Translate(transform.right * -1 * speed * Time.deltaTime); //------->


    }

    void DestroySkill()
    {
        Destroy(gameObject);
    }
}