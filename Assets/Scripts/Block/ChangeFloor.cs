using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject FloorA;     //押すスイッチが最初に下げるべきブロック群を入れる。
    public GameObject FloorB;   //押すスイッチが最初に上げるべきブロック群を入れる。
    int needMove = 0;                   //動かすか。０は動かない。１はＢを上にあげる。２はＡを上にあげる。
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
            if (FloorA.transform.position == upPos)
            {
                needMove = 1;
            }
            else if (FloorA.transform.position == downPos)
            {
                needMove = 2;
            }
        }
        if(needKey)
        {
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
        if(needMove == 1)
        {
            FloorA.transform.position = Vector3.Lerp(FloorA.transform.position, downPos, lerpSpeed * Time.deltaTime);
            FloorB.transform.position = Vector3.Lerp(FloorB.transform.position, upPos, lerpSpeed * Time.deltaTime);
            if (Mathf.Round(FloorB.transform.position.y * 10) / 10 == upPos.y)
            {
                //最後の調整。
                FloorA.transform.position = new Vector3(FloorA.transform.position.x, downPos.y, FloorA.transform.position.z);
                FloorB.transform.position = new Vector3(FloorB.transform.position.x, upPos.y, FloorB.transform.position.z);
                isTrigger = false;  //二度押し禁止。
                needKey = false;
                needMove = 0;
            }
        }
        else if(needMove == 2)
        {
            FloorA.transform.position = Vector3.Lerp(FloorA.transform.position, upPos, lerpSpeed * Time.deltaTime);
            FloorB.transform.position = Vector3.Lerp(FloorB.transform.position, downPos, lerpSpeed * Time.deltaTime);
            if (Mathf.Round(FloorA.transform.position.y * 10) / 10 == upPos.y)
            {
                //最後の調整。
                FloorA.transform.position = new Vector3(FloorA.transform.position.x, upPos.y, FloorA.transform.position.z);
                FloorB.transform.position = new Vector3(FloorB.transform.position.x, downPos.y, FloorB.transform.position.z);
                isTrigger = false;  //二度押し禁止。
                needKey = false;
                needMove = 0;
            }
        }
    }
}
