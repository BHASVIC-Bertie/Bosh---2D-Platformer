using System;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    private Transform player;
    private Vector3 tempPos;
    private Bounds _cameraBounds;
    private Vector3 _targetPos;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //cam  = Camera.main;
    }

    void Start()
    {
        //follow player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //camera boundaries
        /*var height = cam.size;
        var width = height * cam.aspect;
        
        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.max.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.max.y - height;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //follow player
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y+1.8f;
        
        transform.position = tempPos;
    }
}
