using UnityEngine;
using System.Collections;

public class systemMovement : MonoBehaviour {
    //docs.unity3d.com/ScriptReference/Transform-localRotation.html

    public Vector3 RotationYPositive;
    public Vector3 RotationYNegative;

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
            this.transform.Rotate(RotationYPositive);

        }

        if (plzRotatex2)
        {
            this.transform.Rotate(RotationYNegative);
        }


    }
}
