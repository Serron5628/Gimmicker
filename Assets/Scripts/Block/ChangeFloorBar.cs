using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeFloorBar : MonoBehaviour
{
    GameObject[] swiths;
    public int switchNum = 0;

    void Start()
    {
        swiths = GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();
    }
    
    void MoveAnimation()
    {
        for(int i = 0; i < switchNum; i++)
        {
            transform.GetChild(i).gameObject.SendMessage("Anim");
        }
    }
}
