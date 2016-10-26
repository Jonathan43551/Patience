using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    //answers.unity3d.com/questions/824575/change-position-cameras-slider.html

    public Camera mainCamera;

    public float newCameraYPositionCoordinate;
    public float homeCameraYPositionCoordinate;

    // Update is called once per frame
    public void SliderValueChanged(float sliderValue) {
        //Debug.Log(sliderValue);
        newCameraYPositionCoordinate = mainCamera.transform.localPosition.y + sliderValue;
        //Debug.Log("Y coordinate modifier: " + newYPosition);

        //     we're going to try a new way to render the camera and move it around, hopefully we will see a cool change
        //
        //     i didn't make the change...
        //
        //     mainCamera.transform.localPosition = new Vector3(
        //     mainCamera.transform.localPosition.x,
        //     newYPosition,
        //     mainCamera.transform.localPosition.z
        //     );

        mainCamera.transform.localPosition = new Vector3(
        mainCamera.transform.localPosition.x,
        newCameraYPositionCoordinate,
        mainCamera.transform.localPosition.z
        );


    }

    public void SliderGravityValueChanged(float sliderValue)
    {
        Physics.gravity = new Vector3(
            0,
            sliderValue,
            0
            );
        //Debug.Log(Physics.gravity);

    }



    public void ButtonHomePressed()
    {
        //Debug.Log("inside ButtonHomePressed");
        mainCamera.transform.localPosition = new Vector3(
        0,
        homeCameraYPositionCoordinate,
        0
        );

        //Debug.Log("inside ButtonHomePressed");
 //      mainCamera.transform.localPosition = new Vector3(
 //      mainCamera.transform.localPosition.x,
 //      homeYPosition,
 //      mainCamera.transform.localPosition.z
 //      );
 //
    }

}

