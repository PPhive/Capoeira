using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    public float Timer1;
    public float Timer2;
    public GameObject Circle1;
    public GameObject Circle2;
    public bool TwoSpawned;

    void Start()
    {
        TwoSpawned = false;
    }

    void Update()
    {
        Timer1 += Time.deltaTime;
        Expand(Circle1, Timer1);
        if (Timer1 >= 0.1f && !TwoSpawned)
        {
            TwoSpawned = true;
        }
        if (TwoSpawned)
        {
            Timer2 += Time.deltaTime;
            Expand(Circle2, Timer2);
        }
        
        if (Timer1 >= 0.7)
        {  
            Destroy(this.gameObject);
        } 
    }

    void Expand(GameObject Circle, float Timer)
    {
        Circle.transform.localScale += 2 * Mathf.Pow(0.5f, 20*Timer) * new Vector3(1, 1, 0);
    }
}
