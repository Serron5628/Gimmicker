using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorBar : MonoBehaviour
{
    Animator anim;
    public bool firstLeft = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void MoveAnimation()
    {
        anim.SetTrigger("Move");
        firstLeft = !firstLeft;
    }
}
