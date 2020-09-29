using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMassMove : MonoBehaviour
{
    public Vector3 moveX = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);
    
    public float speed = 2.5f;
    public Vector3 beforePos;
    public Vector3 target;
    Rigidbody rigid;
    Animator heroAnim;
    public bool canMove = true;
    public bool moveNow = false;

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
        if (!canMove) return;
        float distance = (transform.position - target).sqrMagnitude;    //二乗。
        if (distance <= 0.002f)  //ほぼ0
        {
            moveNow = false;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            if(heroAnim.GetCurrentAnimatorStateInfo(0).IsTag("Stop")) return;
            TargetPosition();
        }
        Move();
    }

    void TargetPosition()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveNow = true;
            target = transform.position + moveX;
            beforePos = transform.position;
            transform.LookAt(target);
            heroAnim.SetTrigger("Walk");
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveNow = true;
            target = transform.position - moveX;
            beforePos = transform.position;
            transform.LookAt(target);
            heroAnim.SetTrigger("Walk");
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveNow = true;
            target = transform.position + moveZ;
            beforePos = transform.position;
            transform.LookAt(target);
            heroAnim.SetTrigger("Walk");
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveNow = true;
            target = transform.position - moveZ;
            beforePos = transform.position;
            transform.LookAt(target);
            heroAnim.SetTrigger("Walk");
            return;
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            heroAnim.ResetTrigger("Walk");
            heroAnim.SetTrigger("Damage");
            target = beforePos;
        }
    }
}
