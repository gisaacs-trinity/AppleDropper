using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{
    public GameObject basket;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            Debug.Log("Apple Collision!");
            basket.GetComponent<BasketMovement>().loseBasket();
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.tag == "Player")
        {
            basket.GetComponent<BasketMovement>().collectApple();
            Destroy(this.gameObject);
        }
    }
}
