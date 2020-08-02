using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnLogic : MonoBehaviour
{
    private ArrayList rope;
    // connect with HingeJoints
    public GameObject ropeSegment;

    // Start is called before the first frame update
    void Start()
    {
        GameObject segmentInstance = Instantiate(ropeSegment);
        segmentInstance.SendMessage("SetParentGrowTo", GameObject.Find("Player"));
        segmentInstance.SendMessage("SetParentAnchor", gameObject);

        segmentInstance.transform.position = new Vector3(-3, 0, -1);

        Debug.Log(transform.position);
        Debug.Log(GameObject.Find("Player").transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
