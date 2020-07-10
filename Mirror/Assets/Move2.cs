using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2 : MonoBehaviour
{

    public GameObject followTarget;
    public GameObject pivot;

    private Vector3 prevPos;
    private Vector3 prevRot;

    public FloatVariable adjustment;

    public GameObject flip;


    private bool hasChanged;
    public void Start()
    {
        prevPos = followTarget.transform.position;
        prevRot = pivot.transform.eulerAngles;
    }
    public void Update()
    {
        updateMove();
        updateRotate();
    }

    private void updateMove()
    {
        Vector3 currPos = followTarget.transform.position;

        float deltaX = currPos.x - prevPos.x;
        float deltaZ = currPos.z - prevPos.z;

        gameObject.transform.position += new Vector3(-deltaX * adjustment.value, 
                                                     0, 
                                                     deltaZ * adjustment.value);

        prevPos = currPos;
    }

    private void updateRotate()
    {
        Vector3 currRot = pivot.transform.eulerAngles;
        float changeInRot = prevRot.y - currRot.y;

        gameObject.transform.eulerAngles = gameObject.transform.eulerAngles -= new Vector3(0, 0, changeInRot);
        prevRot = currRot;
       
    }


}
