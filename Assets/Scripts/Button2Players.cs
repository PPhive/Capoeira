using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Players : MonoBehaviour
{
    public float timer;
    public GameObject Ripple;
    public GameObject Spark;

    void Update()
    {
        if (timer <= 0)
        {
            Instantiate(Ripple, transform.position, transform.rotation);
            timer = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            Instantiate(Spark, transform.position, transform.rotation);
            GameManager.Instance.GameStartPVP();
            Destroy(this.gameObject);
        }
    }
}
