using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform Player;
    public int DestroyTime;
    public float speed;


    void Start()

    {
        Player = GameObject.Find("Player").transform;

        Invoke("DestroyEnemy", DestroyTime);
    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (Player.transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (Player.transform.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }


    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
