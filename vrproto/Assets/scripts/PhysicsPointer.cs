using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{

    public float defaultlength = 3.0f;
        private LineRenderer lineRenderer = null;
    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaltEnd(defaultlength);

        if (hit.collider)
            endPosition = hit.point;
        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultlength);
        return hit;
    }

    private Vector3 DefaltEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
