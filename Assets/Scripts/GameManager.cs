using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject UI;
    public GameObject Circle;
    public float CircleTargetRadius;
    public GameObject Texts;

    public GameObject playerPrefab;
    public GameObject player1;
    public GameObject player2;
    public GameObject PlayerLost;
    public GameObject PlayerWon;

    public GameObject ButtonStartPVP;

    public Vector3 P1KnobPos;
    public Vector3 P2KnobPos;

    public bool battle;

    public Animator CameraShaker;

    void Awake()
    {
        Instance = this;
        Debug.Log(PlayerWon);
    }

    void Start()
    {
        PlayerWon = player1;
        Debug.Log(PlayerWon);
        Menu();
    }

    void Update()
    {
        if (PlayerWon == null && player2 == null)
        {
            PlayerWon = player1;
        }

        Circle.transform.localScale += (CircleTargetRadius * 2 - Circle.transform.localScale.x)/2 * new Vector3(1, 1, 0.00001f);

        if (battle)
        {
            CircleTargetRadius -= Time.deltaTime / 7;
        }


        if (battle && PlayerLost == player1)
        {
            if (player1 != null && player2 != null)
            {
                CameraShaker.SetTrigger("Shake");
                Destroy(player1);
                PlayerWon = player2;
                Menu();
            }
        }
        else if (battle && PlayerLost == player2)
        {
            if (player1 != null && player2 != null)
            {
                CameraShaker.SetTrigger("Shake");
                Destroy(player2);
                PlayerWon = player1;
                Menu();
            }
        } 
    }

    void Menu()
    {
        Texts.transform.localPosition = new Vector3(0, 0, 0);
        battle = false;
        Circle.transform.localScale = new Vector2(100, 100);
        CircleTargetRadius = 50;
        if (PlayerWon == null)
        {
            PlayerWon = player1;
        }
        if (PlayerWon == player1)
        {
            UI.transform.position = P1KnobPos + new Vector3(0, 1, 0);
        }
        else
        {
            UI.transform.position = P2KnobPos + new Vector3(0, 1, 0);
        }
        Instantiate(ButtonStartPVP, UI.transform.position + new Vector3(3.23f, -2.66f, 0), UI.transform.rotation);
    }

    public void GameStartPVP()
    {
        battle = true;
        Texts.transform.localPosition = new Vector3(0, 0, -100);
        if (PlayerWon == player1)
        {
            UI.transform.position = player1.transform.position + new Vector3(6, 0, 0);
            Instantiate(playerPrefab, player1.transform.position + new Vector3(12, 0, 0), player1.transform.rotation);
        }
        else
        {
            UI.transform.position = player2.transform.position - new Vector3(6, 0, 0);
            Instantiate(playerPrefab, player2.transform.position - new Vector3(12, 0, 0), player2.transform.rotation);
        }
        CircleTargetRadius = 10;
    }

}
