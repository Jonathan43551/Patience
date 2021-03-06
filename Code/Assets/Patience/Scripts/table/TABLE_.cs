﻿using UnityEngine;
using System.Collections;

public class TABLE_ : MonoBehaviour {

    [SerializeField]
    float slideSpeed = 15;

    [SerializeField]
    Vector3 tableHome = new Vector3(0, 0, 0);

    public void FUNCTION_checkForInput() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            this.transform.position += Vector3.forward * slideSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            this.transform.position += Vector3.back * slideSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * slideSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * slideSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) {
            this.transform.position = tableHome;
        }
    }
}