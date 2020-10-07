﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveRockAndPutOn : MonoBehaviour
{
    public GameObject player;
    AMassMove playerScr;
    bool isHadRock = false;
    bool isTrigger = false;
    float putOnX;
    float putOnZ;
    public float onHeadPos = 1.35f;
    public float putOnYPos = -0.5f;
    public bool forwardWall = false;
    public bool having = false;
    int spaceCount = 0;
    Animator playerAnim;
    BoxCollider wall;
    GameObject parent;

    private void Start()
    {
        playerAnim = player.transform.Find("Shape").GetComponent<Animator>();
        wall = transform.Find("Wall").GetComponent<BoxCollider>();
        playerScr = player.gameObject.GetComponent<AMassMove>();
        parent = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        WhereLook();
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //持ってるかつ壁・スイッチを向いてる時は置けない。
                if ((isHadRock && forwardWall) || having || playerScr.moveNow || (isHadRock == false && parent.GetComponent<HaveNow>().haveNow)) return;
                spaceCount++;
                if (spaceCount % 2 == 0)
                {
                    parent.SendMessage("Put");
                    having = true;
                    playerAnim.SetTrigger("Put");
                }
                if (spaceCount % 2 == 1)
                {
                    parent.SendMessage("Have");
                    having = true;
                    playerAnim.SetTrigger("Have");
                }
            }
        }

        //持つ
        if (spaceCount % 2 == 1) HadRock();
        //置く
        if (spaceCount % 2 == 0 && isHadRock) PutOnPosition();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    void HadRock()
    {
        gameObject.transform.rotation = player.transform.rotation;
        if (having)
        {
            playerScr.canMove = false;
            wall.enabled = false;
            //ペンキの動き
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z), Time.deltaTime * 4.5f);
            float distance = (transform.position - new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z)).sqrMagnitude;    //二乗。}
            if (distance <= 0.002f)  //ほぼ0
            {
                transform.position = new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z);
                HavingToFalse();
            }
            return;
        }
        player.gameObject.SendMessage("HaveMat");
        gameObject.transform.position = new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z);
        isHadRock = true;
    }

    void PutOnPosition()
    {
        Vector3 target = new Vector3(player.transform.position.x + putOnX, putOnYPos, player.transform.position.z + putOnZ);
        if (having)
        {
            playerScr.canMove = false;
            wall.enabled = false;
            //ペンキの動き
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 2.6f);
            float distance = (transform.position - target).sqrMagnitude;    //二乗。
            if (distance <= 0.002f)  //ほぼ0
            {
                transform.position = target;
                HavingToFalse();
            }
            return;
        }
        SendNormal();
        isHadRock = false;
        spaceCount = 0;
    }

    void WhereLook()
    {
        if (player.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            putOnX = 0.0f;
            putOnZ = 1.0f;
        }
        if (player.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            putOnX = 0.0f;
            putOnZ = -1.0f;
        }
        if (player.transform.rotation == Quaternion.Euler(0, -90, 0))
        {
            putOnX = -1.0f;
            putOnZ = 0.0f;
        }
        if (player.transform.rotation == Quaternion.Euler(0, 90, 0))
        {
            putOnX = 1.0f;
            putOnZ = 0.0f;
        }
    }

    public void HavingToFalse()
    {
        wall.enabled = true;
        playerScr.canMove = true;
        having = false;
    }

    void SendNormal()
    {
        player.gameObject.SendMessage("NormalMat");
    }
}
