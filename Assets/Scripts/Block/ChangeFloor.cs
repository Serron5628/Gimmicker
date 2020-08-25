using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject firstUpFloor;     //押すスイッチが最初に下げるべきブロック群を入れる。
    public GameObject firstDownFloor;   //押すスイッチが最初に上げるべきブロック群を入れる。
    bool whichFirstUp = true;           //どっちのブロックを動かすか。
    bool isTrigger = false;             //スイッチにTriggerEnterしてるかどうか。
    bool needKey = false;               //キーを押したかどうか。
    public Vector3 upPos = new Vector3(0.0f, 2.5f, 0.0f);   //Inspectorで指定できる、移動させる上の位置。頭上ギリギリの座標は禁止。
    public Vector3 downPos = new Vector3(0.0f, 1.3f, 0.0f); //Inspectorで指定できる、移動させる下の位置。足元ギリギリの座標は禁止。
    public float lerpSpeed = 6.0f;      //床が上がるスピード。値が大きいほど速い。

    private void Update()
    {
        //スイッチ内部に入ってて、かつ、スペースキーを押したら。
        if (isTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            needKey = true;
            Debug.Log("入ったよ");
        }
        if(needKey)
        {
            Debug.Log("押したよ");
            UpAndDown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //スイッチを押さずに出てきたときの対応。
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    void UpAndDown()
    {
        if (whichFirstUp)
        {
            firstDownFloor.transform.position = Vector3.Lerp(firstDownFloor.transform.position, upPos, lerpSpeed * Time.deltaTime);
            firstUpFloor.transform.position = Vector3.Lerp(firstUpFloor.transform.position, downPos, lerpSpeed * Time.deltaTime);
            if (Mathf.Round(firstDownFloor.transform.position.y * 10) / 10 == upPos.y)
            {
                //最後の調整。
                firstDownFloor.transform.position = new Vector3(firstDownFloor.transform.position.x, Mathf.Round(firstDownFloor.transform.position.y * 10) / 10, firstDownFloor.transform.position.z);
                firstUpFloor.transform.position = new Vector3(firstUpFloor.transform.position.x, Mathf.Round(firstUpFloor.transform.position.y * 10) / 10, firstUpFloor.transform.position.z);
                isTrigger = false;  //二度押し禁止。
                whichFirstUp = !whichFirstUp;
                needKey = false;
            }
        }
        else
        {
            firstUpFloor.transform.position = Vector3.Lerp(firstUpFloor.transform.position, upPos, lerpSpeed * Time.deltaTime);
            firstDownFloor.transform.position = Vector3.Lerp(firstDownFloor.transform.position, downPos, lerpSpeed * Time.deltaTime);
            if (Mathf.Round(firstUpFloor.transform.position.y * 10) / 10 == upPos.y)
            {
                //最後の調整。
                firstDownFloor.transform.position = new Vector3(firstDownFloor.transform.position.x, Mathf.Round(firstDownFloor.transform.position.y * 10) / 10, firstDownFloor.transform.position.z);
                firstUpFloor.transform.position = new Vector3(firstUpFloor.transform.position.x, Mathf.Round(firstUpFloor.transform.position.y * 10) / 10, firstUpFloor.transform.position.z);
                isTrigger = false;  //二度押し禁止。
                whichFirstUp = !whichFirstUp;
                needKey = false;
            }
        }
    }
}
