using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    private GameObject parentAnchor;
    private GameObject parentGrowTo;

    // ropes scale only when they're being drawn out, or being re-wound up into the yarn ball
    private bool isScaling = true;
    public float MAX_SIZE = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parentGrowTo != null && parentAnchor != null)
        {
            Vector3 distanceVector = parentGrowTo.transform.position - parentAnchor.transform.position;
            if (distanceVector.magnitude > MAX_SIZE) {
                distanceVector = distanceVector.normalized * MAX_SIZE;
            }

            Vector3 midpoint = distanceVector / 2 + parentAnchor.transform.position;
            // potentially mandate that all rope stay on the floor?
            // midpoint.y = 0.5;

            transform.position = midpoint;
            transform.LookAt(parentGrowTo.transform.position);
        }
    }

    void SetParentAnchor(GameObject parentAnchor) {
        this.parentAnchor = parentAnchor;
    }

    void SetParentGrowTo(GameObject parentGrowTo) {
        this.parentGrowTo = parentGrowTo;
    }
}
