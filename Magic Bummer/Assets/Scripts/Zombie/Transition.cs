using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    //fix 30.11.2021
    protected Player _taget;

    public virtual bool Check() 
    {
        return false;
    }
}
