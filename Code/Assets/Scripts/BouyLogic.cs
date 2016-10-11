using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouyLogic : MonoBehaviour
{
    public int distanceDeletionFromCamera;
    //public GameObject MainCamera;

    public void CheckDeleteOrUpdateName()
    {
        //var vectorToTargetPlane = transform.position - checkDeletionPlane.transform.position;
        //var vectorToTargetCamera = transform.position - checkDeletionCamera.transform.position;

        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (Vector3.Distance(MainCamera.transform.position, this.transform.position) >= distanceDeletionFromCamera)
        {
            //Debug.Log("checkDeletionCamera??");
            Destroy(this.gameObject, 1);
        } else {
            //call updateName to grab the new location and use it as it's name suffix
            //transform.TransformVector(new Vector3(0, 0, 0) - transform.position);
            updateName();
            //this.gameObject.SetActive(true);
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
}


