using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobinSkill : MonoBehaviour
{
    const float speed = 9f; // ���ǵ�
    const float gravity = -20f; // ȭ�쿡 ��ġ�� �߷� ���
    const float angle = 45f; // �߻簢��
    private float time; //
    private Vector2 velocity; //

    void Start()
    {
        Invoke("DestroySkill", 0.7f);
        float radians = angle * Mathf.Deg2Rad;
        velocity.x = speed * Mathf.Cos(radians);
        velocity.y = speed * Mathf.Sin(radians);
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (transform.rotation.y == 0)
            position.x += velocity.x * Time.deltaTime*speed;
        else
            position.x -= velocity.x * Time.deltaTime * speed;

        position.y += velocity.y * Time.deltaTime + 0.007f * gravity * Mathf.Pow(time, 2f);

        transform.position = position;

        time += Time.deltaTime;
    }

    void DestroySkill()
    {
        Destroy(gameObject);
    }
}
