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
        if (Input.GetMouseButtonDown(1))      // right-click to shoot rope
            StartGrapple();

        if (Input.GetMouseButtonUp(1))        // release to cancel
            StopGrapple();

        if (isGrappling)
            UpdateRope();
    }

    void StartGrapple()
    {
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // cast a ray from the player toward the cursor
        RaycastHit2D hit = Physics2D.Raycast(rb.position, mouseWorldPos - rb.position, 30f, grappleMask);

        if (hit.collider != null)
        {
            grapplePoint = hit.point;
            isGrappling = true;

            joint.enabled = true;
            joint.connectedAnchor = grapplePoint;
            joint.distance = Vector2.Distance(transform.position, grapplePoint);

            // enable rope visual
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }
    }

    void UpdateRope()
    {
        // draw rope
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, grapplePoint);

        // OPTIONAL: slowly pull rope taut
        if (joint.distance > 1f)
            joint.distance -= ropeSpeed * Time.deltaTime;
    }

    void StopGrapple()
    {
        isGrappling = false;
        joint.enabled = false;
        lineRenderer.enabled = false;
    }
}