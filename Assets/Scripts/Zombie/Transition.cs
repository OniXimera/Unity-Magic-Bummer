using UnityEngine;

public class Transition : MonoBehaviour
{
    //fix 05.12.2021
    protected Player _taget;

    public virtual bool Check() 
    {
        return false;
    }
}
