using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    public NoPhysicsMovement Player1;

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
        if (IsDotInTriangle(transform.position, Player1.DotNew, Player1.DotOld, Player1.DotRoot)) 
        {
            Player1.pause = true;
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
}
