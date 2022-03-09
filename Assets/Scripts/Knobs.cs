using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knobs : MonoBehaviour
{
    public GameObject Parent;
    public Movement ParentScript;
    public GameObject Blood;
    public GameObject Spark;
    void Start()
    {
        Parent = transform.parent.gameObject;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, GameManager.Instance.UI.transform.position) > GameManager.Instance.CircleTargetRadius
            &&
            ParentScript.CurrentKnob == this.gameObject
            )
        {
            Instantiate(Spark, transform.position, transform.rotation);
            GameManager.Instance.PlayerLost = Parent;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            //Debug.Log("aaaaaaaaaaaaa");
            Instantiate(Blood, transform.position, transform.rotation);
            GameManager.Instance.PlayerLost = Parent;
            //Debug.Log("bbbbbbbbb");
        }

    }
}
