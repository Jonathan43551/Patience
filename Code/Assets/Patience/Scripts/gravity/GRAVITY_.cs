using UnityEngine;
using System.Collections;

public class GRAVITY_ : MonoBehaviour {
    public bool ACTIVATE_addYGravity;
    public Vector3 addY;

    public bool ACTIVATE_subtractYGravity;
    public Vector3 subtractY;

    public Vector3 latestGravity;

    public void addYGravity()
    {
        if (ACTIVATE_addYGravity) {
        Physics.gravity = Physics.gravity + addY;
            latestGravity = Physics.gravity;
            Debug.Log(Physics.gravity);
        }


    }

    public void subtractYGravity()
    {
        if (ACTIVATE_subtractYGravity)
        {
            Physics.gravity = Physics.gravity - subtractY;
            latestGravity = Physics.gravity;
            Debug.Log(Physics.gravity);
        }
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

