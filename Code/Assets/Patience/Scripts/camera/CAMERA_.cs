using UnityEngine;
using System.Collections;

public class CAMERA_ : MonoBehaviour {

    public bool checkVector;

    public Vector3 vectorToCheck;
    
    public void checkVectorFromSelf()
    {
        if (checkVector) {
            Debug.Log(" ____ : CAMERA_ : vectorFromSelf : " + (vectorToCheck - transform.position));
            Debug.Log(" ____ : CAMERA_ : vectorMagnitudeFromSelf : " + (vectorToCheck - transform.position).magnitude);
            checkVector = false;
        }

    }
}
