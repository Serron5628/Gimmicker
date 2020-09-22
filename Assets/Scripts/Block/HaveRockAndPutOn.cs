using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveRockAndPutOn : MonoBehaviour
{
    public GameObject player;
    bool isHadRock = false;
    bool isTrigger = false;
    float putOnX;
    float putOnZ;
    public float onHeadPos = 0.0f;
    public float putOnYPos = 2.0f;
    public bool forwardWall = false;
    int spaceCount = 0;

    void Update()
    {
        //どこを向いてるかで値を決める。移動の仕方によって変わる。
        ImitationWhereLook();
        
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isHadRock && forwardWall) return;
                spaceCount++;
            }
        }

        HadRock();
        //岩が持たれる・置かれる場所へ自分（岩）を移動させる。とキーを離した時の動作。
        PutOnPosition();
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーがColliderに入ってる時にスペースを押すと。
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
        if(spaceCount % 2 == 1)
        {
            gameObject.transform.rotation = player.transform.rotation;
            isHadRock = true;
        }
    }

    void PutOnPosition()
    {
        if (isHadRock)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z);
            //キーを押したら向いてる方向に置く。
            if (spaceCount % 2 == 0 && forwardWall == false)
            {
                gameObject.transform.position = new Vector3(player.gameObject.transform.position.x + putOnX, putOnYPos, player.gameObject.transform.position.z + putOnZ);
                isHadRock = false;
                spaceCount = 0;
            }
        }
    }

    void ImitationWhereLook()
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
}
