using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorBar : MonoBehaviour
{
    Animator anim;
    public bool firstLeft = true;
    string which;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void MoveAnimation()
    {
        if (firstLeft) which = "Left";
        else if (!firstLeft) which = "Right";
        anim.SetTrigger(which);
        firstLeft = !firstLeft;
    }
}
