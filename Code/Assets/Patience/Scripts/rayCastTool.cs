using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class rayCastTool : MonoBehaviour
{
    // FUNCTION_triageWithCOSMO
    public int worldIdentifier = -509;
    public int transactionIdentifier = -500000;
    public void FUNCTION_triageWithCOSMO(string objectLocationTriageWithCOSMO)
    {
        Debug.Log(worldIdentifier + "^" + transactionIdentifier + objectLocationTriageWithCOSMO);
        transactionIdentifier++;
    }

    // FUNCTION_switchParticleColor<VARIANTS>
    public Rigidbody ACTIVE_rayCastPoint_Particle;
    
    public Rigidbody rayCastPoint_ParticleOptionRed;
    public Rigidbody rayCastPoint_ParticleOptionBlue;
    public Rigidbody rayCastPoint_ParticleOptionGreen;

    public void FUNCTION_switchParticleColorToYellow()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionRed;
    }

    public void FUNCTION_switchParticleColorToBlue()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionBlue;
    }

    public void FUNCTION_switchParticleColorToGreen()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionGreen;
    }
    
    // FUNCTION_switchRayCastMode
    public enum rayCastModeOptions
    {
        anchor,
        link,
    };
    public rayCastModeOptions activeRayCastModeOption;

    public void FUNCTION_switchRayCastMode()
    {

        if (activeRayCastModeOption == rayCastModeOptions.anchor)
        {
            activeRayCastModeOption = rayCastModeOptions.link;
        }
        else
        {
            activeRayCastModeOption = rayCastModeOptions.anchor;
        }
        //Debug.Log(activeRayCastModeOption);
    }
    
    // FUNCTION_toggleActivationPlane
    public GameObject workSurfacePlane;
    public GameObject helpPanel;
    
    public void FUNCTION_toggleActivationPlane()
    {
        if (workSurfacePlane.activeInHierarchy)
        {
            workSurfacePlane.SetActive(false);
        }
        else
        {
            workSurfacePlane.SetActive(true);
        }
    }

    public void FUNCTION_toggleActivationHelp()
    {
        if (helpPanel.activeInHierarchy)
        {
            helpPanel.SetActive(false);
        }
        else
        {
            helpPanel.SetActive(true);
        }
    }
    
    // Instantiate Variables
    public Vector3 VECTOR3_spawnDistance;
    public int INT_raycastDistanceMax;

    void Update()
    {
        //Debug.Log(activeRayCastModeOption);
        //Debug.Log(rayCastModeOptions.link);

        if (Input.GetMouseButton(0))
        {
            // This main loop which acts as the core of Patience, was copied from a fantastic tutorial that showed me how to create gameObjects
            // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial
            // Learn how to make an isometric 3D survival shooter game.

            Ray RAY_cameraToMousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HIT_cameraToMousePosition;
            if (Physics.Raycast(RAY_cameraToMousePosition, out HIT_cameraToMousePosition, INT_raycastDistanceMax))
            {
                //Debug.DrawLine(RAY_cameraToMousePosition.origin, HIT_cameraToMousePosition.point);
                Debug.Log(HIT_cameraToMousePosition.transform.name);

                Instantiate(ACTIVE_rayCastPoint_Particle, (HIT_cameraToMousePosition.point + VECTOR3_spawnDistance), transform.rotation);
            }
        }

        
        }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            // This main loop which acts as the core of Patience, was copied from a fantastic tutorial that showed me how to create gameObjects
            // https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial
            // Learn how to make an isometric 3D survival shooter game.



            Ray RAY_cameraToMousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HIT_cameraToMousePosition;
            if (Physics.Raycast(RAY_cameraToMousePosition, out HIT_cameraToMousePosition, INT_raycastDistanceMax))
            {
               // Debug.DrawRay(RAY_cameraToMousePosition);
                //Debug.Log("trying to draw line");



                //Debug.Log(HIT_cameraToMousePosition.transform.name);

                //Instantiate(ACTIVE_rayCastPoint_Particle, (HIT_cameraToMousePosition.point + VECTOR3_spawnDistance), transform.rotation);
            }
        }




    }
}
