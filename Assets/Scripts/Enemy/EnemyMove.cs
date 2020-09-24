using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 x = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 z = new Vector3(0.0f, 0.0f, 1.0f);

    float speed;
    Vector3 beforePos;
    Vector3 target;
    Rigidbody rigid;
    public bool needMove = true;
    public bool moveZ = true;
    public bool moveX = false;
    public GameObject player;
    AMassMove playerScr;
    Animator anim;

    void Start()
    {
        playerScr = player.GetComponent<AMassMove>();
        speed = playerScr.speed;
        target = transform.position;
        beforePos = transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        anim = transform.Find("Shape").gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(playerScr.target == target || (playerScr.beforePos == target && beforePos == playerScr.target)) player.SendMessage("Damage");
        if (playerScr.canMove == false) return;
        if (!needMove) return;
        float distance = (transform.position - target).sqrMagnitude;    //二乗。
        if (distance <= 0.002f)  //ほぼ0
        {
            if (moveX)
            {
                transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, transform.position.z);
            }
            if(moveZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.RoundToInt(transform.position.z));
            }

            TargetPosition();
        }
        Move();
    }

    void TargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(moveZ) target = transform.position + z;
            if(moveX) target = transform.position + x;
            beforePos = transform.position;
            transform.LookAt(target);
            anim.SetTrigger("Walk");
            return;
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy"))
        {
            target = beforePos;
            if (moveX) x *= -1;
            if (moveZ) z *= -1;
        }
        if(other.gameObject.CompareTag("Player")) target = beforePos;
    }
}
