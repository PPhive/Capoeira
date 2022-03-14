using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [System.Serializable]
    public class PlayerData 
        {
            public int PlayerIndex;
            public PlayerInput Input;
            public Vector2 KnobMoveNew, KnobMoveOld, KnobRoot;
            public float Length, Angle;
            public float RotationSpeed;
        }

    [SerializeField]
    public List<PlayerData> PlayerList;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        /*
        if (GameManager2.Instance.IsDotInTriangle(GameManager2.Instance.transform.position, PlayerList[0].KnobRoot, PlayerList[0].KnobMoveNew, PlayerList[0].KnobMoveOld)) 
        {
            PlayerList[0].RotationSpeed = 0;
        }
        */
    }

    public void PlayerUpdate(PlayerData PlayerAsking) 
    {
        if (PlayerAsking.Input.ChangeBuffered)
        {
            ChangeFeet(PlayerAsking);
        }
        PlayerAsking.KnobMoveOld = PlayerAsking.KnobMoveNew;
        PlayerRotateAroundRootBySpeed(PlayerAsking);
    }


    public void ChangeFeet(PlayerData PlayerAsking)
    {
        Vector2 Temp;
        Temp = PlayerAsking.KnobRoot;
        PlayerAsking.KnobRoot = PlayerAsking.KnobMoveNew;
        PlayerAsking.KnobMoveNew = Temp;
        PlayerAsking.Angle = RotateBySpeed(PlayerAsking.Angle, 180f);
        PlayerAsking.Input.ChangeBuffered = false;
    }

    public void PlayerRotateAroundRootBySpeed(PlayerData PlayerAsking)
    {
        PlayerAsking.Angle = RotateBySpeed(PlayerAsking.Angle, PlayerAsking.RotationSpeed * Time.deltaTime);
        float AngleRad = Mathf.Deg2Rad * PlayerAsking.Angle;
        PlayerAsking.KnobMoveNew = PlayerAsking.KnobRoot + new Vector2(Mathf.Sin(AngleRad), Mathf.Cos(AngleRad));
    }

    public float RotateBySpeed(float Angle, float Speed) 
    {
        Angle += Speed;
        if (Angle >= 360) 
        {
            Angle -= 360f;
        }
        if (Angle < 0) 
        {
            Angle += 360f;
        }
        return Angle;
    }
}
