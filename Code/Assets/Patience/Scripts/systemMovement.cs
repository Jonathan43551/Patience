using UnityEngine;
using System.Collections;

public class systemMovement : MonoBehaviour {
    //docs.unity3d.com/ScriptReference/Transform-localRotation.html

    public float slideSpeed;

    public Vector3 rotationVariant1;
    public Vector3 rotationVariant2;
    public Vector3 rotationVariant3;

    public bool plzRotatex1;
    public bool plzRotatex2;
    public bool plzRotatex3;

    public Vector3 rotationVariantE;
    public Vector3 rotationVariantD;

    public void BooleanRotationxV1(bool plzRotateV1) {
        //Debug.Log(" _ _ : systemMovement : BooleanRotationxV1 : " + plzRotateV1);
        plzRotatex1 = plzRotateV1;
    }

    public void BooleanRotationxV2(bool plzRotateV2) {
        //Debug.Log(" _ _ : systemMovement : BooleanRotationxV2 : " + plzRotateV2);
        plzRotatex2 = plzRotateV2;
    }

    public void BooleanRotationxV3(bool plzRotateV3) {
        //Debug.Log(" _ _ : systemMovement : BooleanRotationxV3 : " + plzRotateV3);
        plzRotatex3= plzRotateV3;
    }

    // Update is called once per frame
    void Update () {
        if (plzRotatex1) {
            //Debug.Log(" _ _ : systemMovement : plzRotatex1");
            this.transform.Rotate(rotationVariant1);
        }

        if (plzRotatex2) {
            //Debug.Log(" _ _ : systemMovement : plzRotatex2");
            this.transform.Rotate(rotationVariant2);
        }

        if (plzRotatex3) {
            //Debug.Log(" _ _ : systemMovement : plzRotatex3");
            this.transform.Rotate(rotationVariant3);
        }

        // maybe we could use a single increment using Q and E
        if (Input.GetKey(KeyCode.E)) {
            this.transform.Rotate(rotationVariantE);
        }

        if (Input.GetKey(KeyCode.D)) {
            this.transform.Rotate(rotationVariantD);
        }
    }
}
