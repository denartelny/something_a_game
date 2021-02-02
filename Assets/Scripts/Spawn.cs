using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;
    public GameObject item;
    Vector2 playerPos;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y);
    }
    public void SpawnDroppedItem()
    {
       
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
