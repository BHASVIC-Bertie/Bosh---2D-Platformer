using System;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public LineRenderer lineRenderer;
    public float ropeSpeed = 20f;
    public LayerMask grappleMask;

    private DistanceJoint2D joint;
    private Vector2 grapplePoint;
    Vector2 mousePos;
    private bool isGrappling = false;


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;

        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            // left click to shoot rope
            StartGrapple();
            print("grapple");
        }
        Vector2 lookDir = mousePos - rb.position;
        if (Input.GetMouseButtonDown(1))
        {
            // right click to cancel
            StopGrapple();
            print("grapple stopped");
        }
    }

    void StartGrapple()
    {
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // cast a ray from the player towards the mouse cursor
        RaycastHit2D hit = Physics2D.Raycast(rb.position, mouseWorldPos, 30f, grappleMask);
        
       
        if (hit.collider != null)
        {
            print("hit");
            grapplePoint = hit.point;
            isGrappling = true;

            joint.enabled = true;
            joint.connectedAnchor = grapplePoint;
            joint.distance = Vector2.Distance(transform.position, grapplePoint);

            //show the rope moving
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
            UpdateRope();
        }
        else
        {
            print("miss");
        }
    }

    void UpdateRope()
    {
        // draw rope
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, grapplePoint);
        
    }
    void StopGrapple()
    {
        isGrappling = false;
        joint.enabled = false;
        lineRenderer.enabled = false;
    }
}