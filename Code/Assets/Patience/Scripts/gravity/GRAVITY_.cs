using UnityEngine;
using System.Collections;

public class GRAVITY_ : MonoBehaviour {
    public bool addGravityOnce;
    public Vector3 addGravityVector3;

    public bool subtractGravityOnce;
    public Vector3 subtractGravityVector3;

    public Vector3 latestGravity;

    public void addValueChanged(bool toggleValue) {
        Debug.Log(" ... : addValueChanged : " + toggleValue);
        addGravityOnce = toggleValue;
    }

    public void subtractValueChanged(bool toggleValue)
    {
        Debug.Log(" ... : subtractValueChanged : " + toggleValue);
        subtractGravityOnce = toggleValue;
    }

    public void addGravity()
    {
        if (addGravityOnce) {
        Physics.gravity = Physics.gravity + addGravityVector3;
            //Debug.Log(Physics.gravity);
            addGravityOnce = false;
        }


    }

    public void subtractGravity()
    {
        if (subtractGravityOnce)
        {
            Physics.gravity = Physics.gravity - subtractGravityVector3;
            //Debug.Log(Physics.gravity);
            subtractGravityOnce = false;
        }
    }

    void FixedUpdate()
    {
        // we want to be able to keep tabs on the latest gravity value
        latestGravity = Physics.gravity;
    }

    //    // this vector3 will be applied to all bodies in the scene
    //    public Vector3 vector3_Gravity_Value_To_Set { get; set; }
    //
    //    // this function will reset gravity to 0,0,0, then apply 'new_Vector3_Gravity_Value_To_Set'
    //    public void reset_To_Zero_Gravity() {
    //        Physics.gravity = new Vector3(0,0,0) + vector3_Gravity_Value_To_Set;
    //        //Debug.Log(Physics.gravity);
    //
}

