using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpElevetor : MonoBehaviour
{
    public Vector3 upPos = new Vector3(0.0f, 4.35f, 0.0f);
    public float speed = 1.0f;
    GameObject player;
    bool need = true;

    void Start()
    {
        player = transform.Find("Player").gameObject;
    }
    
    void Update()
    {
        if (need == false) return;
        transform.position = Vector3.MoveTowards(transform.position, upPos, speed * Time.deltaTime);
        float distance = (transform.position - upPos).sqrMagnitude;    //二乗。
        if (distance <= 0.002f)
        {
            transform.position = upPos;
            player.gameObject.transform.parent = null;
            player.gameObject.GetComponent<AMassMove>().target = player.transform.position;
            player.gameObject.GetComponent<AMassMove>().beforePos = player.transform.position;
            player.GetComponent<AMassMove>().rideElevator = false;
            need = false;
        }
    }
}
