using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private float speedMod = 0;
    private float appleInterval = 2;
    private float appleFallSpeed = 0;

    public GameObject applePrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        StartCoroutine(SpawnApples());
        InvokeRepeating("speedUpTree", 10, 5);
        InvokeRepeating("speedUpApples", 10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position.x > 10)
        {
            rb.velocity = new Vector2(-(speed+speedMod), 0);
        }
        else if (transform.position.x < -10)
        {
            rb.velocity = new Vector2(speed+speedMod, 0);
        }
    }

    void speedUpTree()
    {
        Debug.Log("Speed Up!");
        if (speedMod < 20)
        {
            speedMod++;
        }
    }

    void speedUpApples()
    {
        if (appleFallSpeed > 100)
        {
            appleFallSpeed += 10;
        }
        if (appleInterval > 0.4)
        {
            appleInterval -= 0.2f;
        }
    }

    IEnumerator SpawnApples()
    {
        while (true)
        {
            // Makes a prefab after an interval
            yield return new WaitForSeconds(appleInterval);
            GameObject apple = Instantiate(applePrefab, transform.position, Quaternion.identity);
            apple.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -appleFallSpeed));
            apple.GetComponent<AppleBehavior>().basket = player;
        }
    }
}
