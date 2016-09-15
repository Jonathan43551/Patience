using UnityEngine;
using System.Collections;

public class AnchorController : MonoBehaviour {

   // public GameObject[] anchorList; 

    // Update is called once per frame
    void Update() {
        
        }
    //GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

    //anchorList = new anchorList[anchors.Length];


    public void AnchorCheckup()
    {
        print("######");
        print("hello attempting to check/delete objects");
        print("######");

        GameObject[] anchorGameObjects = GameObject.FindGameObjectsWithTag("Anchor");

        foreach (GameObject anchorName in anchorGameObjects)
        {
            //print(anchorName.name);
            if (anchorName != null)
            {
                anchorName.GetComponent<BouyLogic>().CheckDeleteOrUpdateName();
            }
        }
    }


}

