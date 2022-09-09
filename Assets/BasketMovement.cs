using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketMovement : MonoBehaviour
{
    float x;
    [HideInInspector]
    public int scoreCtr = 0;
    [HideInInspector]
    public int highScoreCtr;
    public Text scoreField;
    public Text highScoreField;
    public Text gameOver;

    public GameObject basketPrefab;
    public GameObject Floor;
    [HideInInspector]
    //public GameObject[] basketArray;
    public int basketsLeft = 3;
    private GameObject basket1;
    private GameObject basket2;
    private GameObject basket3;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        basket1 = Instantiate(basketPrefab, new Vector3(pos.x, pos.y + .75f,pos.z), Quaternion.identity, transform);
        basket2 = Instantiate(basketPrefab, pos, Quaternion.identity, transform);
        basket3 = Instantiate(basketPrefab, new Vector3(pos.x, pos.y - .75f, pos.z), Quaternion.identity, transform);

        // Trying to set alpha to 0 on game start
        //transform.GetComponent<SpriteRenderer>()

        highScoreCtr = PlayerPrefs.GetInt("HighScore");
        highScoreField.text = "High Score: " + highScoreCtr;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        // Cancel out Dead Space to bring player to stop (just good practice)
        if (x > -0.01 && x < 0.01)
        {
            x = 0;
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, -4, 0);
    }

    public void collectApple()
    {
        ++scoreCtr;
        scoreField.text = " Apples: " + scoreCtr;
        if (scoreCtr > highScoreCtr)
        {
            highScoreField.text = "High Score: " + scoreCtr;
        }
        Debug.Log("Collected Apple! " + scoreCtr);
    }

    public void loseBasket()
    {
        Debug.Log("Apple Lost!");
        if (basketsLeft == 3)
        {
            Destroy(basket1.gameObject);
            basketsLeft--;
        }
        else if (basketsLeft == 2)
        {
            Destroy(basket2.gameObject);
            basketsLeft--;
        }
        else if (basketsLeft <= 1)
        {
            Destroy(basket3.gameObject);
            Debug.Log("Game Over!");
            gameOver.text = "Game Over!";
            PlayerPrefs.SetInt("HighScore", scoreCtr);
        }
    }
}
