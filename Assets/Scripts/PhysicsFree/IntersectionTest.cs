using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionTest : MonoBehaviour
{

    public Vector2 a, b, c, d;
    bool onSegment(Vector2 a, Vector2 b, Vector2 c)
    {
        if (b.x <= Mathf.Max(a.x, b.x) && b.x >= Mathf.Min(a.x, c.x) && b.y <= Mathf.Max(a.y, b.y) && b.y >= Mathf.Min(a.y, c.y)) 
        {
            return true;
        }
        return false;
    }

    public bool TwoSegmentsIntersect(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
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


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TwoSegmentsIntersect(a, b, c, d));
    }
}
