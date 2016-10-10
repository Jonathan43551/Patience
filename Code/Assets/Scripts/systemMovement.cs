using UnityEngine;
using System.Collections;

public class systemMovement : MonoBehaviour {
    //docs.unity3d.com/ScriptReference/Transform-localRotation.html

    public Vector3 Rotationx1;
    public Vector3 Rotationx2;

    public bool plzRotatex1;
    public bool plzRotatex2;

    public void BooleanRotationx1(bool plzRotate)
    {
        plzRotatex1 = plzRotate;
    }

    public void BooleanRotationx2(bool plzRotate)
    {
        plzRotatex2 = plzRotate;
    }

    // Update is called once per frame
    void Update () {
        if (plzRotatex1)
        {
            this.transform.Rotate(Rotationx1);

        }

        if (plzRotatex2)
        {
            this.transform.Rotate(Rotationx2);
        }


    }
}
