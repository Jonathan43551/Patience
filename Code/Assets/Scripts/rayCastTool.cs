using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class rayCastTool : MonoBehaviour
{
    public Rigidbody rayCastPoint_Particle;

    public Rigidbody block;

    public float speed = 50f;

    public float spawnHeight = 10;

    public GameObject CreatedObjectCounterText;

    Text CreatedObjectText;

    public int CreatedObjectCounter;


   // public EditorController EditorController;



    void Start()
    {


        CreatedObjectText = GameObject.Find("count Text").GetComponent<Text>();
        CreatedObjectText.text = " Count: " + CreatedObjectCounter;
    }


    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {

       if (Input.GetMouseButton(0))
       {
            if(!rayCastPoint_Particle)
            {
                rayCastPoint_Particle = rigidbody.FindGameObjectWithTag("Anchor");

            }


           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           if (Physics.Raycast(ray, out hit, 400))
           {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.transform.name);

      //          if (hit.transform.name == "RestartButton")
      //          {
      //              EditorController.RestartGame();
      //          }
                //FireRocket();
                Instantiate(rayCastPoint_Particle, hit.point, transform.rotation);

                CreatedObjectCounter++;

                
               
            
            }
    
    
       }



        CreatedObjectText.text = " Count: " + CreatedObjectCounter;


    }





    public void FreeButtonClick()
    {
        CreatedObjectCounter++;
    }



}
