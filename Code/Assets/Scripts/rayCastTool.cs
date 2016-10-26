using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class rayCastTool : MonoBehaviour
{
    public float spawnHeight = 10;

    public Rigidbody ACTIVE_rayCastPoint_Particle;

    public Rigidbody rayCastPoint_ParticleOptionYellow;
    public Rigidbody rayCastPoint_ParticleOptionBlue;
    public Rigidbody rayCastPoint_ParticleOptionGreen;

    public Button switchParticleColorToYellow;
    public Button switchParticleColorToBlue;
    public Button switchParticleColorToGreen;

    public Button switchRayCastMode;

    public GameObject workSurfacePlane;
    public GameObject helpPanel;

    public enum rayCastModeOptions
    {
        anchor,
        link,
    };
    public rayCastModeOptions activeRayCastModeOption;


    public void FUNCTION_switchParticleColorToYellow()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionYellow;
    }

    public void FUNCTION_switchParticleColorToBlue()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionBlue;
    }

    public void FUNCTION_switchParticleColorToGreen()
    {
        ACTIVE_rayCastPoint_Particle = rayCastPoint_ParticleOptionGreen;
    }

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

    public void FUNCTION_toggleActivationPlane()
    {
        if (workSurfacePlane.activeInHierarchy)
        {
            workSurfacePlane.SetActive(false);
        } else
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


    public Vector3 VECTOR3_spawnDistance;
    public int raycastDistanceMax;

    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {
        //Debug.Log(activeRayCastModeOption);
        //Debug.Log(rayCastModeOptions.link);

        if (Input.GetMouseButton(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistanceMax))
            {
                //Debug.DrawLine(ray.origin, hit.point);
                //Debug.Log(hit.transform.name);

                Instantiate(ACTIVE_rayCastPoint_Particle, (hit.point + VECTOR3_spawnDistance), transform.rotation);

            }
        }
    }
}
