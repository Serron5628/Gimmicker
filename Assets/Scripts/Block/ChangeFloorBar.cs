using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorBar : MonoBehaviour
{
    public int switchNum = 0;
    
    void MoveAnimation()
    {
        for(int i = 0; i < switchNum; i++)
        {
            transform.GetChild(i).gameObject.SendMessage("Anim");
        }
    }
}
