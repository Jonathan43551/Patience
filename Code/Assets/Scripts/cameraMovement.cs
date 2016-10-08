using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    //answers.unity3d.com/questions/824575/change-position-cameras-slider.html

    public Camera mainCamera;

    public float newYPosition;

    void start()
    {
      float newYPosition = mainCamera.transform.localPosition.y;
    }






    // Update is called once per frame
    public void SliderValueChanged(float sliderValue) {
        newYPosition = newYPosition + sliderValue;
        //Debug.Log("Y coordinate modifier: " + newYPosition);
    }


    public void Update()
    {
        mainCamera.transform.localPosition = new Vector3(
        mainCamera.transform.localPosition.x,
        newYPosition,
        mainCamera.transform.localPosition.z
        );

        Debug.Log(mainCamera.transform.localPosition);
    }

}

