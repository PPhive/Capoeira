using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode MyKey;
    public bool KeyDown = false;

    void Update()
    {
        if (Input.GetKeyDown(MyKey)) 
        {
            KeyDown = true;
        }
    }
}
