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
    public float onHeadPos = 1.35f;
    public float putOnYPos = -0.5f;
    public bool forwardWall = false;
    int spaceCount = 0;
    //Animator playerAnim;

    private void Start()
    {
        //playerAnim = player.transform.Find("Shape").GetComponent<Animator>();
    }

    void Update()
    {
        WhereLook();
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //持ってるかつ壁・スイッチを向いてる時は置けない。
                if (isHadRock && forwardWall) return;
                spaceCount++;
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
        gameObject.transform.position = new Vector3(player.transform.position.x, onHeadPos, player.transform.position.z);
        gameObject.transform.rotation = player.transform.rotation;
        isHadRock = true;
    }

    void PutOnPosition()
    {
        gameObject.transform.position = new Vector3(player.gameObject.transform.position.x + putOnX, putOnYPos, player.gameObject.transform.position.z + putOnZ);
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
}
