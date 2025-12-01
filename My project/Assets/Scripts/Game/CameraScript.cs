using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    private Camera cam;

    private float minX, maxX, minY, maxY;

    void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        // Find player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Find level bounds using BoxCollider2D
        EdgeCollider2D levelBounds = GameObject.Find("LevelBounds").GetComponent<EdgeCollider2D>();
        if (levelBounds != null)
        {
            minX = levelBounds.bounds.min.x;
            maxX = levelBounds.bounds.max.x;
            minY = levelBounds.bounds.min.y;
            maxY = levelBounds.bounds.max.y;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Follow player
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y + 1.8f; // vertical offset
        tempPos.z = transform.position.z;

        // Clamp to level bounds
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        tempPos.x = Mathf.Clamp(tempPos.x, minX + camWidth, maxX - camWidth);
        tempPos.y = Mathf.Clamp(tempPos.y, minY + camHeight, maxY - camHeight);

        transform.position = tempPos;
    }
}
