using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouyLogic : MonoBehaviour
{
    public GameObject deletionPlane;

    public void CheckDeleteOrUpdateName()
    {

        var vectorToTarget = transform.position - deletionPlane.transform.position;
        
        if (vectorToTarget.y <= .1)
        {
            //Debug.Log("attempting to delete " + this.gameObject.name);
            Destroy(this.gameObject, 1);
        } else if (vectorToTarget.y >= 200)
        {
            Destroy(this.gameObject, 1);
        } else if (vectorToTarget.z <= -50)
        {
            Destroy(this.gameObject, 1);
        } else if (Vector3.Distance(deletionPlane.transform.position, transform.position) >= 2000)
        {
            Destroy(this.gameObject, 1);
        } else {
            //call updateName to grab the new location and use it as it's name suffix
            updateName();
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


