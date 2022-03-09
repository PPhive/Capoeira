using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RotateAroundRigidbody by:
//https://answers.unity.com/questions/10093/rigidbody-rotating-around-a-point-instead-on-self.html

public class Movement : MonoBehaviour
{
    public GameObject Knob1;
    public GameObject Knob2;
    public Rigidbody2D RB;
    public GameObject CurrentKnob;
    public KeyCode SpinKey;

    public GameObject Ripple;

    public CircleCollider2D HitRecieve;

    public float Rotatespeed;
    public float RotateSpeedChangeSpeed;
    public float TargetRotateSpeed;

    public SpriteRenderer Knob1Renderer;
    public SpriteRenderer Knob2Renderer;
    public SpriteRenderer BodyRenderer;
    public TrailRenderer Trail1Renderer;
    public TrailRenderer Trail2Renderer;

    void Start()
    {
        RB = this.GetComponent<Rigidbody2D>();
        HitRecieve = this.GetComponent<CircleCollider2D>();
        if (GameManager.Instance.player1 == null)
        {
            GameManager.Instance.player1 = this.gameObject;
            SpinKey = KeyCode.Q;
        }
        else
        {
            GameManager.Instance.player2 = this.gameObject;
            SpinKey = KeyCode.P;
            Knob1Renderer.color = new Vector4(0.3f, 0.3f, 0.3f, 1);
            Knob2Renderer.color = new Vector4(0.3f, 0.3f, 0.3f, 1);
            BodyRenderer.color = new Vector4(0.3f, 0.3f, 0.3f, 1);
            Trail1Renderer.startColor = new Vector4(0.3f, 0.3f, 0.3f, 1);
            Trail1Renderer.endColor = new Vector4(0.3f, 0.3f, 0.3f, 1);
            Trail2Renderer.startColor = new Vector4(0.3f, 0.3f, 0.3f, 1);
            Trail2Renderer.endColor = new Vector4(0.3f, 0.3f, 0.3f, 1);
        }
        transform.Rotate(new Vector3 (0,0,1), 180);
    }

    void Update()
    {
        if (Input.GetKey(SpinKey))
        {
            TargetRotateSpeed = 360;
        }
        else
        {
            TargetRotateSpeed = 180;
        }

        if (Rotatespeed > TargetRotateSpeed)
        {
            Rotatespeed -= RotateSpeedChangeSpeed * Time.deltaTime;
        }
        else if (Rotatespeed < TargetRotateSpeed)
        {
            Rotatespeed += RotateSpeedChangeSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(SpinKey))
        {
            if (CurrentKnob == Knob2)
            {
                CurrentKnob = Knob1;
                Instantiate(Ripple, CurrentKnob.transform.position, CurrentKnob.transform.rotation);
            }
            else
            {
                CurrentKnob = Knob2;
                Instantiate(Ripple, CurrentKnob.transform.position, CurrentKnob.transform.rotation);
            }
        }

        if (GameManager.Instance.player1 == this.gameObject)
        {
            GameManager.Instance.P1KnobPos = CurrentKnob.transform.position;
        }
        else if (GameManager.Instance.player2 == this.gameObject)
        {
            GameManager.Instance.P2KnobPos = CurrentKnob.transform.position;
        }
        
    }

    void FixedUpdate()
    {
        rotateRigidBodyAroundPointBy(RB, CurrentKnob.transform.position, new Vector3(0,0,1), Rotatespeed * Time.deltaTime);
    }

    //RotateAroundRigidbody by:
    //https://answers.unity.com/questions/10093/rigidbody-rotating-around-a-point-instead-on-self.html
    public void rotateRigidBodyAroundPointBy(Rigidbody2D rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }
}
