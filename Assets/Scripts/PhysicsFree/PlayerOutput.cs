using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutput : MonoBehaviour
{
    public int MyIndex;
    public GameObject Knob1, Knob2;
    void Start()
    {
        
    }

    void Update()
    {
        /*
        transform.position = (PlayerManager.Instance.PlayerList[MyIndex].KnobRoot + PlayerManager.Instance.PlayerList[MyIndex].KnobRoot) / 2;
        transform.eulerAngles = transform.forward * PlayerManager.Instance.PlayerList[MyIndex].Angle;
        */
        transform.position = PlayerManager.Instance.PlayerList[MyIndex].KnobRoot;
        transform.eulerAngles = PlayerManager.Instance.PlayerList[MyIndex].Angle * transform.forward * (-1);
        //Knob2.transform.position = PlayerManager.Instance.PlayerList[MyIndex].KnobMoveNew;
        //Knob2.transform.position = PlayerManager.Instance.PlayerList[MyIndex].KnobMoveNew;
    }
}
