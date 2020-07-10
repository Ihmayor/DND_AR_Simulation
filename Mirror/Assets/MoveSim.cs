using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSim : MonoBehaviour
{

    public Camera followCam;
    public GameObject pivot;

    public FloatVariable adjustment;

    private float prevX;
    private float prevZ;

    private Quaternion prevRotation;

    private void Start()
    {
        prevX = followCam.transform.position.x;
        prevZ = followCam.transform.position.z;
        prevRotation = pivot.transform.rotation;
    }

    void Update()
    {

        rotateAdjustment();


        float changeInX = prevX - followCam.transform.position.x;
        float changeInZ = prevZ - followCam.transform.position.z;

        this.gameObject.transform.position += new Vector3(changeInZ * adjustment.value,
                                                          changeInX * adjustment.value,
                                                          0);

        prevX = followCam.transform.position.x;
        prevZ = followCam.transform.position.z;
        
    }

    private void rotateAdjustment()
    {
        float changeInRot = prevRotation.eulerAngles.y - pivot.transform.rotation.eulerAngles.y;

        Debug.Log("Change in rot: " + changeInRot);
        Debug.Log(pivot.transform.rotation.eulerAngles.y);

        gameObject.transform.eulerAngles = gameObject.transform.eulerAngles += new Vector3(0, 0, changeInRot);
        prevRotation = pivot.transform.rotation;
    }
}
