using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This is just a proof of concept, We are not using this anymore. All movement detection has been moved to player manager.

public class NoPhysicsMovement : MonoBehaviour
{
    public GameObject KnobA;
    public GameObject KnobB;
    public GameObject TrailA;
    public GameObject TrailB;
    public GameObject KnobStill;
    public GameObject KnobMove;
    public Vector2 DotRoot, DotOld, DotNew;
    private bool ChangeBuffered;

    public bool pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeBuffered = true;
        }
    }
    
    void FixedUpdate()
    {
        if (!pause) 
        {
            if (ChangeBuffered)
            {
                ChangeFeet();
            }
            DotOld = KnobMove.transform.position;
            DotRoot = KnobStill.transform.position;
            transform.RotateAround(KnobStill.transform.position, transform.forward, 180 * Time.deltaTime);
            DotNew = KnobMove.transform.position;
        }
    }

    public void ChangeFeet() 
    {
        GameObject Temp;
        Temp = KnobStill;
        KnobStill = KnobMove;
        KnobMove = Temp;
        ChangeBuffered = false;
    }
}
