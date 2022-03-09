using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 TargetPos;
    public float TargetSize;
    public Camera MyCamera;

    void Start()
    {
        MyCamera = this.GetComponent<Camera>();
    }

    void Update()
    {
        if (GameManager.Instance.battle)
        {
            if (GameManager.Instance.player1 != null && GameManager.Instance.player2 != null)
            {
                //PVP
                TargetSize = Vector3.Distance(GameManager.Instance.P1KnobPos, GameManager.Instance.P2KnobPos)/3 + 6;
                TargetPos = new Vector3(
                                       (GameManager.Instance.UI.transform.position.x * 1 + GameManager.Instance.P1KnobPos.x + GameManager.Instance.P2KnobPos.x) / 3,
                                       (GameManager.Instance.UI.transform.position.y * 1 + GameManager.Instance.P1KnobPos.y + GameManager.Instance.P2KnobPos.y) / 3,
                                       -15
                                       );
            }
            else
            {
                //Single
                TargetSize = 15;
            }
        }
        else
        {
            //Menu
            TargetSize = Vector3.Distance(GameManager.Instance.PlayerWon.transform.position, GameManager.Instance.UI.transform.position) / 2 + 6;

            if (GameManager.Instance.PlayerWon == GameManager.Instance.player2)
            {
                TargetPos = new Vector3(
                                       GameManager.Instance.P2KnobPos.x,
                                       GameManager.Instance.P2KnobPos.y + 1,
                                       -15
                                       );
            }
            else
            {
                TargetPos = new Vector3(
                                       GameManager.Instance.P1KnobPos.x,
                                       GameManager.Instance.P1KnobPos.y + 1,
                                       -15
                                       );
            }
        }

        MyCamera.orthographicSize += (TargetSize - MyCamera.orthographicSize) * 3 * Time.deltaTime;
        transform.position += new Vector3 (
                                           (TargetPos.x-transform.position.x) * 3 * Time.deltaTime,
                                           (TargetPos.y-transform.position.y) * 3 * Time.deltaTime,
                                           0
                                          );

    }
}
