using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutput : MonoBehaviour
{
    public int MyIndex;
    public GameObject Knob1, Knob2;
    private Vector2 LastFrameRootPos;
    
    void Start()
    {
        //LastFrameRootPos = PlayerManager.Instance.PlayerList[MyIndex].KnobRoot;
    }

    void Update()
    {
        transform.position = PlayerManager.Instance.PlayerList[MyIndex].KnobRoot;
        transform.eulerAngles = PlayerManager.Instance.PlayerList[MyIndex].Angle * transform.forward * (-1);
        if (PlayerManager.Instance.PlayerList[MyIndex].KnobRoot != LastFrameRootPos) 
        {
            Vector3 temp = Knob1.transform.position;
            Knob1.transform.position = Knob2.transform.position;
            Knob2.transform.position = temp;
        }
        LastFrameRootPos = PlayerManager.Instance.PlayerList[MyIndex].KnobRoot;
        if (PlayerManager.Instance.PlayerList[MyIndex].Dead) 
        {
            Destroy(gameObject);
        }
    }
}
