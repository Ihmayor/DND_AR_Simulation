using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{

    public FloatVariable speed;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= new Vector3(0, 0, speed.value);    
    }
}
