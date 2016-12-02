using UnityEngine;
using System.Collections;

public class CAMERA_ : MonoBehaviour {

    public bool checkVector;
    public Vector3 vectorToCheck;

    public bool home_CameraPosition0Once;
    public Vector3 home_CameraPosition0;

    public bool home_CameraPosition1Once;
    public Vector3 home_CameraPosition1;

    public bool home_CameraPosition2Once;
    public Vector3 home_CameraPosition2;
    
    public void checkVectorFromSelf() {
        if (checkVector) {
            Debug.Log(" ____ : CAMERA_ : vectorFromSelf : " + (vectorToCheck - transform.position));
            Debug.Log(" ____ : CAMERA_ : vectorMagnitudeFromSelf : " + (vectorToCheck - transform.position).magnitude);
            checkVector = false;
        }
    }

    public void button_home_CameraPosition0() {
        if (home_CameraPosition0Once) {
            this.transform.position = home_CameraPosition0;
            home_CameraPosition0Once = false;
        }
    }

    public void button_home_CameraPosition1() {
        if (home_CameraPosition1Once) {
            this.transform.position = home_CameraPosition1;
            home_CameraPosition1Once = false;
        }
    }

    public void button_home_CameraPosition2() {
        if (home_CameraPosition2Once) {
            this.transform.position = home_CameraPosition0;
            home_CameraPosition2Once = false;
        }
    }


    public void toggle_home_CameraPosition0Once(bool toggleValue) {
        home_CameraPosition0Once = toggleValue;
    }

    public void toggle_home_CameraPosition1Once(bool toggleValue) {
        home_CameraPosition1Once = toggleValue;
    }

    public void toggle_home_CameraPosition2Once(bool toggleValue) {
        home_CameraPosition2Once = toggleValue;
    }

    public float button_camera_moveSpeed;

    public void button_camera_decreaseX() {
        this.transform.position.Set(this.transform.position.x - button_camera_moveSpeed, this.transform.position.y, this.transform.position.z);

        Debug.Log(" ] ] [ : button_camera_decreaseX : " + button_camera_moveSpeed);
    }

    public void button_camera_increaseX() {
        this.transform.position.Set(this.transform.position.x + button_camera_moveSpeed, this.transform.position.y, this.transform.position.z);
        Debug.Log(" ] ] [ : button_camera_increaseX : " + button_camera_moveSpeed);
    }

    public void button_camera_decreaseY() {
        this.transform.position.Set(this.transform.position.x, this.transform.position.y - button_camera_moveSpeed, this.transform.position.z);
        Debug.Log(" ] ] [ : button_camera_decreaseY : " + button_camera_moveSpeed);
    }

    public void button_camera_increaseY() {
        this.transform.position.Set(this.transform.position.x, this.transform.position.y + button_camera_moveSpeed, this.transform.position.z);
        Debug.Log(" ] ] [ : button_camera_increaseY : " + button_camera_moveSpeed);
    }

    public void button_camera_decreaseZ() {
        this.transform.position.Set(this.transform.position.x, this.transform.position.y, this.transform.position.z - button_camera_moveSpeed);
        Debug.Log(" ] ] [ : button_camera_decreaseZ : " + button_camera_moveSpeed);
    }

    public void button_camera_increaseZ() {
        this.transform.position.Set(this.transform.position.x, this.transform.position.y, this.transform.position.z + button_camera_moveSpeed);
        Debug.Log(" ] ] [ : button_camera_increaseZ : " + button_camera_moveSpeed);
    }



}
