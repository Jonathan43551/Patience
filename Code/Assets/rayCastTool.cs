using UnityEngine;
using System.Collections;
using System.IO;


public class rayCastTool : MonoBehaviour
{
    public Rigidbody rayCastPoint_Particle;

    public Rigidbody block;

    public float speed = 50f;

    public float spawnHeight = 10;





  //  void SpawnBlock()
  //  {
  //
  //
  //      for (int y = 0; y < 1; y++)
  //      {
  //          // Rigidbody rocketClone = (Rigidbody)Instantiate(rocket, transform.position, transform.rotation);
  //
  //          Rigidbody rocketClone = (Rigidbody)Instantiate(block, new Vector3(y, spawnHeight, y), transform.rotation);
  //
  //          rocketClone.velocity = transform.forward * speed;
  //
  //
  //      }
  //
  //
  //  }
  //

    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {
    //    if (Input.GetMouseButton(0))
    //    {
    //        SpawnBlock();
    //    }


       if (Input.GetMouseButton(0))
       {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           if (Physics.Raycast(ray, out hit, 400))
           {
               //FireRocket();
               Instantiate(rayCastPoint_Particle, hit.point, transform.rotation);
           }
    
    
       }
    



    }

}
