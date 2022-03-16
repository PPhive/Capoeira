using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;
    public NoPhysicsMovement Player1;

    //Temporary game ender after a player hits another;
    private bool GameOver;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!GameOver) 
        {
            for (int i = 0; i < PlayerManager.Instance.PlayerList.Count; i++)
            {
                PlayerManager.Instance.PlayerUpdate(PlayerManager.Instance.PlayerList[i]);
            }

            for (int i = 0; i < PlayerManager.Instance.PlayerList.Count; i++)
            {

                for (int j = 0; j < PlayerManager.Instance.PlayerList.Count; j++)
                {
                    if (PlayerManager.Instance.PlayerList[i] != PlayerManager.Instance.PlayerList[j])
                    {
                        bool DotIn = IsDotInTriangle(
                                                    PlayerManager.Instance.PlayerList[i].KnobRoot,
                                                    PlayerManager.Instance.PlayerList[j].KnobRoot,
                                                    PlayerManager.Instance.PlayerList[j].KnobMoveOld,
                                                    PlayerManager.Instance.PlayerList[j].KnobMoveNew
                                                    );

                        bool CrossOld = DoesTwoSegmentsIntersect(
                                                                PlayerManager.Instance.PlayerList[i].KnobRoot,
                                                                PlayerManager.Instance.PlayerList[i].KnobMoveOld,
                                                                PlayerManager.Instance.PlayerList[j].KnobMoveOld,
                                                                PlayerManager.Instance.PlayerList[j].KnobMoveNew
                                                                );
                        bool CrossNew = DoesTwoSegmentsIntersect(
                                                                PlayerManager.Instance.PlayerList[i].KnobRoot,
                                                                PlayerManager.Instance.PlayerList[i].KnobMoveNew,
                                                                PlayerManager.Instance.PlayerList[j].KnobMoveOld,
                                                                PlayerManager.Instance.PlayerList[j].KnobMoveNew
                                                                );
                        if (CrossNew || CrossNew || DotIn)
                        {
                            PlayerManager.Instance.PlayerList[i].Dead = true;
                            GameOver = true;
                        }
                    }
                }
            }
        } 
    }

    public bool IsDotInTriangle(Vector2 Dot, Vector2 A, Vector2 B, Vector2 C)
    {
        float AreaABC = FindTriangleArea(A, B, C);
        float AreaDotSum = FindTriangleArea(A, B, Dot) + FindTriangleArea(B, C, Dot) + FindTriangleArea(C, A, Dot);
        if (Mathf.Round(AreaABC * 1000) / 1000 == Mathf.Round(AreaDotSum * 1000) / 1000)
        {
            return true;
        }
        return false;
    }

    public float FindTriangleArea(Vector2 A, Vector2 B, Vector2 C)
    {
        float[] SideLength = new float[] { Vector2.Distance(A, B), Vector2.Distance(B, C), Vector2.Distance(C, A) };
        float S = (SideLength[0] + SideLength[1] + SideLength[2]) / 2;
        float Area = Mathf.Sqrt(S * (S - SideLength[0]) * (S - SideLength[1]) * (S - SideLength[2]));
        return Area;
    }

    public bool DoesTwoSegmentsIntersect(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
    {
        int o1 = Orientation(p1, q1, p2);
        int o2 = Orientation(p1, q1, q2);
        int o3 = Orientation(p2, q2, p1);
        int o4 = Orientation(p2, q2, q1);

        if (o1 != o2 && o3 != o4)
        {
            return true;
        }
        return false;
    }

    int Orientation(Vector2 a, Vector2 b, Vector2 c)
    {
        float val = (a.y - b.y) * (a.x - c.x) - (a.x - b.x) * (a.y - c.y);

        if (val == 0)
        {
            return 0;  // collinear
        }
        return (val > 0) ? 1 : 2; // clock or counterclock wise
    }
}
