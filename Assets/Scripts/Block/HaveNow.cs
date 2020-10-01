using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveNow : MonoBehaviour
{
    public bool haveNow = false;

    void Have()
    {
        haveNow = true;
    }

    void Put()
    {
        haveNow = false;
    }
}
