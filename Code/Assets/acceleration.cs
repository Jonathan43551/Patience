using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceleration : MonoBehaviour {

    public Vector3 rotationPoint; 

    void LateUpdate() {
        
        this.transform.RotateAround(rotationPoint,Vector3.up,0.1f);
    }
}
