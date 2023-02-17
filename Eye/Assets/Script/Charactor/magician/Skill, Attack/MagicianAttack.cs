using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAttack : MonoBehaviour
{
    public float speed; //투사체 스피드
    void Start()
    {
        Invoke("DestroyAttack", 0.4f);
    }

    void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(transform.right * speed * Time.deltaTime); //------->
        else
            transform.Translate(transform.right * -1 * speed * Time.deltaTime); //------->


    }

    void DestroyAttack()
    {
        Destroy(gameObject);
    }
}
