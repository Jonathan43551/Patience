using UnityEngine;
using System.Collections;

public class CAMERA_ : MonoBehaviour {

    public bool checkVector;
    public Vector3 vectorToCheck;

    //public bool home_CameraPosition0Once;
    public Vector3 home_CameraPosition0;

    //public bool home_CameraPosition1Once;
    public Vector3 home_CameraPosition1;

    //public bool home_CameraPosition2Once;
    public Vector3 home_CameraPosition2;
    
    public void FUNCTION_checkVectorFromSelf() {
        if (checkVector) {
            Debug.Log(" ____ : CAMERA_ : vectorFromSelf : " + (vectorToCheck - transform.position));
            Debug.Log(" ____ : CAMERA_ : vectorMagnitudeFromSelf : " + (vectorToCheck - transform.position).magnitude);
            checkVector = false;
        }
    }

    public void button_home_CameraPosition0() {
        this.transform.position = home_CameraPosition0;
    }

    public void button_home_CameraPosition1() {
        this.transform.position = home_CameraPosition1;
    }

    public void button_home_CameraPosition2() {
        this.transform.position = home_CameraPosition0;
    }

    public float button_camera_moveSpeed;

    public void button_camera_decreaseX() {
        transform.position = new Vector3( (transform.position.x - button_camera_moveSpeed), transform.position.y, transform.position.z );
        Debug.Log(" ] ] [ : button_camera_decreaseX : " + transform.localPosition);
    }

    public void button_camera_increaseX() {
        transform.position = new Vector3( (transform.position.x + button_camera_moveSpeed), transform.position.y, transform.position.z);
        Debug.Log(" ] ] [ : button_camera_increaseX : " + transform.localPosition);
    }

    public void button_camera_decreaseY() {
        transform.position = new Vector3( transform.position.x, (transform.position.y - button_camera_moveSpeed), transform.position.z);
        Debug.Log(" ] ] [ : button_camera_decreaseY : " + transform.localPosition);
    }

    public void button_camera_increaseY() {
        transform.position = new Vector3( transform.position.x, (transform.position.y + button_camera_moveSpeed), transform.position.z);
        Debug.Log(" ] ] [ : button_camera_increaseY : " + transform.localPosition);
    }

    public void button_camera_decreaseZ() {
        transform.position = new Vector3( transform.position.x, transform.position.y, (transform.position.z - button_camera_moveSpeed));
        Debug.Log(" ] ] [ : button_camera_decreaseZ : " + transform.localPosition);
    }

    public void button_camera_increaseZ() {
        transform.position = new Vector3( transform.position.x, transform.position.y, (transform.position.z + button_camera_moveSpeed));
        Debug.Log(" ] ] [ : button_camera_increaseZ : " + transform.localPosition);
    }

    public void FixedUpdate() {
        if (Input.GetKey(KeyCode.Q)) {
            button_camera_increaseX();
        }

        if (Input.GetKey(KeyCode.W)) {
            button_camera_increaseY();
        }

        if (Input.GetKey(KeyCode.A)) {
            button_camera_decreaseX();
        }

        if (Input.GetKey(KeyCode.S)) {
            button_camera_decreaseY();
        }

        if (Input.GetKey(KeyCode.Z)) {
            button_camera_decreaseZ();
        }

        if (Input.GetKey(KeyCode.X)) {
            button_camera_increaseZ();
        }
    }

    public int FORGE_generateDistanceMaximum = 200;
    private int spawnTimeDelay;


    public void FUNCTION_checkMouseInput(FORGE_ forgeReference) {
        if (Input.GetMouseButton(0)) {
            // This main loop which acts as the core of Patience, was copied from a fantastic tutorial that showed me how to create gameObjects
            // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial
            // Learn how to make an isometric 3D survival shooter game.

            Ray RAY_cameraToMousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HIT_cameraToMousePosition;



            if (Physics.Raycast(RAY_cameraToMousePosition, out HIT_cameraToMousePosition, FORGE_generateDistanceMaximum) && (spawnTimeDelay == 0)) {

                //Debug.DrawLine(RAY_cameraToMousePosition.origin, HIT_cameraToMousePosition.point);
                forgeReference.FUNCTION_generateRigidbody(HIT_cameraToMousePosition.point);
                //forgeReference.FUNCTION_generateRigidbody(HIT_cameraToMousePosition.point + Vector3.forward);
                //forgeReference.FUNCTION_generateRigidbody(HIT_cameraToMousePosition.point + Vector3.back);
                //forgeReference.FUNCTION_generateRigidbody(HIT_cameraToMousePosition.point + Vector3.left);
                //forgeReference.FUNCTION_generateRigidbody(HIT_cameraToMousePosition.point + Vector3.right);

                spawnTimeDelay += 5;


            }
        } else {
            if(spawnTimeDelay >= 1) {
                spawnTimeDelay--;
            }
        }
    }   
}
