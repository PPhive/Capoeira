using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode MyKey;
    public bool ChangeBuffered = false;
    public bool ReleaseBuffered = false;

    void Update()
    {
        if (Input.GetKeyDown(MyKey)) 
        {
            ChangeBuffered = true;
        }

        if (Input.GetKeyUp(MyKey)) 
        {
            ReleaseBuffered = true;
        }
    }
}
