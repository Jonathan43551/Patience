using UnityEngine;
using System.Collections;

public class AnchorClone : MonoBehaviour {

    // updating each frame costs too much CPU and 
    public int timeDelayReset = 63;

    public GameObject deletionPlane;
    int updateDelay = 63;
    
    void checkDeletion()
    {
        var vectorToTarget = transform.position - deletionPlane.transform.position;

        if (vectorToTarget.y <= .1)
        {
            //Debug.Log("attempting to delete " + this.gameObject.name);
            Destroy(this.gameObject, 1);
        }

        if(vectorToTarget.y >= 200)
        {
            Destroy(this.gameObject, 1);
        }

        if (vectorToTarget.z <= -50)
        {
            Destroy(this.gameObject, 1);
        }

        if (Vector3.Distance(deletionPlane.transform.position, transform.position) >= 2000)
        {
            Destroy(this.gameObject, 1);
        }



    }


   void updateName()
   {   
       
       string positionName = this.transform.position + "";

       string switchedNegativeName = positionName.Replace("-", "n");

       string removeLeftBracket = switchedNegativeName.Replace("(", "");

       string removeRightBracket = removeLeftBracket.Replace(")", "");

       string removeZero = removeRightBracket.Replace(".0", "");

       string replacecomma = removeZero.Replace(",", "-");

       string postName = replacecomma.Replace(" ", "");

       this.gameObject.name = "Anchor-" + postName;
       
   }

//   // Update is called once per frame
//   void Update () {
//
//       if(updateDelay >= 0)
//       {
//           if (updateDelay == 0)
//           {
//               checkDeletion();
//               updateName();
//
//               //reset timer
//               updateDelay = timeDelayReset;
//           }
//           updateDelay--;
//
//       }
//   }



}
