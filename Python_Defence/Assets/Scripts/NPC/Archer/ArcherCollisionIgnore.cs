using UnityEngine;
using UnityEngine.Tilemaps;

namespace PythonDefence.NPC
{
    public class ArcherCollisionIgnore : MonoBehaviour
    {
        [SerializeField] private Collider2D[] characterColliders;
        [SerializeField] private TilemapCollider2D TileMap;
        // Start is called before the first frame update
        void Start()
        {
            TileMap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<TilemapCollider2D>();
            for (int i = 0; i <= characterColliders.Length - 1; i++)
            {
                Physics2D.IgnoreCollision(characterColliders[i], TileMap, true);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

