using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouyLogic : MonoBehaviour
{

    public void CheckDeleteOrUpdateName()
    {
        GameObject deletionPlane = GameObject.FindGameObjectWithTag("TooCool");



        var vectorToTarget = transform.position - deletionPlane.transform.position;
        
        if (vectorToTarget.y <= .4)
        {
            //Debug.Log("attempting to delete " + this.gameObject.name);
            Destroy(this.gameObject, 1);
        } else if (vectorToTarget.y >= 200)
        {
            Destroy(this.gameObject, 1);
        } else if (vectorToTarget.z <= -50)
        {
            Destroy(this.gameObject, 1);
        } else if (Vector3.Distance(deletionPlane.transform.position, transform.position) >= 100)
        {
            Destroy(this.gameObject, 1);
        } else {
            //call updateName to grab the new location and use it as it's name suffix
            transform.TransformVector(new Vector3(0, 0, 0) - transform.position);
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


