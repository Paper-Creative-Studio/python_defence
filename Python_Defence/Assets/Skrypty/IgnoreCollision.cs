using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] private BoxCollider2D characterCollider;
    [SerializeField] private TilemapCollider2D TileMap;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, TileMap, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
