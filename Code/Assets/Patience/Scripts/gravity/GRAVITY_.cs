using UnityEngine;
using Zenject;

// [Hard Dance] - Stonebank - Be Alright (feat. EMEL) [Monstercat Release] 
// www.youtube.com/watch?v=X5a0tLjGOww

public class GRAVITY_ : MonoBehaviour {
    // we'll use these variables to trigger changes to our environment
    public Vector3 addGravityVector3;
    public Vector3 subtractGravityVector3;

    public Vector3 latestGravity;
    public Vector3 zeroedGravity;

    // Physics.gravity changes will be applied to all game objects in the scene that have a rigidbody with gravity enabled
    public void subtractGravity() {
        Physics.gravity = Physics.gravity - subtractGravityVector3;
    }
    
    public void zeroGravity() {
        Physics.gravity = zeroedGravity;
    }

    public void addGravity() {
        Physics.gravity = Physics.gravity + addGravityVector3;
    } 

    public void FUNCTION_checkForInput() {
        if (Input.GetKey(KeyCode.R)) {
            subtractGravity();
        }

        if (Input.GetKey(KeyCode.F)) { // neutralize gravity
            zeroGravity();
        }

        if (Input.GetKey(KeyCode.V)) {
            addGravity();
        }

        // we want record the latest gravity value
        latestGravity = Physics.gravity;
    }
}

