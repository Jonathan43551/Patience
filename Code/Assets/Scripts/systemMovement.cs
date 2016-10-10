using UnityEngine;
using System.Collections;

public class systemMovement : MonoBehaviour {
    //docs.unity3d.com/ScriptReference/Transform-localRotation.html

    public Vector3 RotationINCR;
    public Vector3 RotationDECR;

    public bool plzRotateINCR;
    public bool plzRotateDECR;

    public void BooleanRotationINCR(bool plzRotate)
    {
        plzRotateINCR = plzRotate;
    }

    public void BooleanRotationDECR(bool plzRotate)
    {
        plzRotateDECR = plzRotate;
    }

    // Update is called once per frame
    void Update () {
        if (plzRotateINCR)
        {
            this.transform.Rotate(RotationINCR);

        }

        if (plzRotateDECR)
        {
            this.transform.Rotate(RotationDECR);
        }


    }
}
