using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    //answers.unity3d.com/questions/824575/change-position-cameras-slider.html

    public Camera mainCamera;

    public float newYPosition;
    public float homeYPosition;

    // Update is called once per frame
    public void SliderValueChanged(float sliderValue) {
        Debug.Log(sliderValue);
        newYPosition = newYPosition + sliderValue;
        //Debug.Log("Y coordinate modifier: " + newYPosition);

        mainCamera.transform.localPosition = new Vector3(
        mainCamera.transform.localPosition.x,
        newYPosition,
        mainCamera.transform.localPosition.z
        );
    }


    public void ButtonHomePressed()
    {
        Debug.Log("inside ButtonHomePressed");
        mainCamera.transform.localPosition = new Vector3(
        mainCamera.transform.localPosition.x,
        homeYPosition,
        mainCamera.transform.localPosition.z
        );
        
    }

}

