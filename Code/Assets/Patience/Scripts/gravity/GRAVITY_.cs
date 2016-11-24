using UnityEngine;
using System.Collections;

public class GRAVITY_ : MonoBehaviour {
    // we'll use these variables to trigger changes to our environment
    // GRAVITY_subContainer is able to create an instance of GRAVITY_ with zenject and executes two methods

    public bool addGravityOnce;
    public Vector3 addGravityVector3;

    public bool subtractGravityOnce;
    public Vector3 subtractGravityVector3;

    public Vector3 latestGravity;

    public void addValueChanged(bool toggleValue) {
        //Debug.Log(" ... : GRAVITY_ : addValueChanged : " + toggleValue);
        addGravityOnce = toggleValue;
    }

    public void subtractValueChanged(bool toggleValue)
    {
        //Debug.Log(" ... : GRAVITY_ : subtractValueChanged : " + toggleValue);
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
}

