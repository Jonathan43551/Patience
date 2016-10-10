using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class rayCastTool : MonoBehaviour
{
    public float spawnHeight = 10;

    public Rigidbody ACTIVE_rayCastPoint_Particle;

    public Rigidbody rayCastPoint_ParticleOptionRed;
    public Rigidbody rayCastPoint_ParticleOptionBlue;
    public Rigidbody rayCastPoint_ParticleOptionGreen;

    public Button switchParticleColorToRed;
    public Button switchParticleColorToBlue;
    public Button switchParticleColorToGreen;

    public void FUNCTION_switchParticleColorToRed()
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

    public Vector3 VECTOR3_spawnDistance;
    public int raycastDistanceMax;

    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {

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
