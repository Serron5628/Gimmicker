using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToZero : MonoBehaviour
{
    bool needZero = true;
    float speed = 2.5f;
    Vector3 target;
    public GameObject parentGmj;

    private void Start()
    {
        target = new Vector3(gameObject.transform.position.x, parentGmj.transform.position.y, gameObject.transform.position.z);
    }

    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;    //二乗。
        if (distance <= 0.002f)  //ほぼ0
        {
            transform.position = target;
            transform.parent = parentGmj.transform;
            needZero = false;
        }

        if (needZero == true)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
    }
}
