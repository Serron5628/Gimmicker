﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMassMove : MonoBehaviour
{
    public Vector3 moveX = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);

    public float speed = 7.0f;
    public Vector3 beforePos;
    public Vector3 target;
    public int moveSpeed = 20;
    Rigidbody rigid;
    Animator heroAnim;

    void Start()
    {
        target = transform.position;
        beforePos = transform.position;
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        heroAnim = transform.Find("Shape").gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;    //二乗。
        if (distance <= 0.0002f)  //ほぼ0
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));

            TargetPosition();
        }
        Move();
    }

    void TargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            heroAnim.SetTrigger("Walk");
            target = transform.position + moveX;
            beforePos = transform.position;
            transform.LookAt(target);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            heroAnim.SetTrigger("Walk");
            target = transform.position - moveX;
            beforePos = transform.position;
            transform.LookAt(target);
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            heroAnim.SetTrigger("Walk");
            target = transform.position + moveZ;
            beforePos = transform.position;
            transform.LookAt(target);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            heroAnim.SetTrigger("Walk");
            target = transform.position - moveZ;
            beforePos = transform.position;
            transform.LookAt(target);
            return;
        }
    }

    void Move()
    {
        //if (target == transform.position) return;
        //transform.position += (target-transform.position) / moveSpeed;
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            target = beforePos;
        }
    }
}
