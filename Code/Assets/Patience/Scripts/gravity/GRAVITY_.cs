using UnityEngine;
using System.Collections;
using Zenject;

// [Hard Dance] - Stonebank - Be Alright (feat. EMEL) [Monstercat Release] 
// www.youtube.com/watch?v=X5a0tLjGOww

public class GRAVITY_ : MonoBehaviour {
    // we'll use these variables to trigger changes to our environment
    // GRAVITY_subContainer is able to create an instance of GRAVITY_ with zenject and executes two methods
    public bool addGravityOnce;
    public bool subtractGravityOnce;

    public Vector3 addGravityVector3;
    public Vector3 subtractGravityVector3;

    public Vector3 latestGravity;
    public Vector3 zeroedGravity;

    public void toggleAddGravityOnce(bool toggleAddValue) {
        //Debug.Log(" ... : GRAVITY_ : addValueChanged");
        addGravityOnce = toggleAddValue;
    }
    
    public void toggleSubtractGravityOnce(bool toggleSubtractValue) {
        //Debug.Log(" ... : GRAVITY_ : subtractValueChanged");
        subtractGravityOnce = toggleSubtractValue;
    }

    // Physics.gravity changes will be applied to all game objects in the scene that have a rigidbody with gravity enabled
    public void addGravity() {
        if (addGravityOnce) {
            Physics.gravity = Physics.gravity + addGravityVector3;
            addGravityOnce = false;
        }
    }

    public void subtractGravity() {
        if (subtractGravityOnce) {
            Physics.gravity = Physics.gravity - subtractGravityVector3;
            subtractGravityOnce = false;
        }
    }

    public void FixedUpdate() {
        if (Input.GetKey(KeyCode.R)) {
            toggleSubtractGravityOnce(true);
        }
        
        if (Input.GetKey(KeyCode.F)) {
            toggleAddGravityOnce(true);
        }

        if (Input.GetKey(KeyCode.V)) {
            // hopefully zeroed out gravity
            Physics.gravity = zeroedGravity;
        }


        // we want to be able to  tabs on the latest gravity value
        latestGravity = Physics.gravity;

    }
}

