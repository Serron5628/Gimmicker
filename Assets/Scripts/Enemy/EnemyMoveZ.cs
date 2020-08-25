using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveZ : MonoBehaviour
{
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);

    public float speed = 8.0f;
    Vector3 beforePos;
    Vector3 target;
    Rigidbody rigid;

    void Start()
    {
        target = transform.position;
        beforePos = transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;    //二乗。
        if (distance <= 0.002f)  //ほぼ0
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.RoundToInt(transform.position.z));

            TargetPosition();
        }
        Move();
    }

    void TargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            target = transform.position + moveZ;
            beforePos = transform.position;
            transform.LookAt(target);
            return;
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            target = beforePos;
            moveZ *= -1;
        }
    }
}
