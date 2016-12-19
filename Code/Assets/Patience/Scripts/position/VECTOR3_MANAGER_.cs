using UnityEngine;
using System.Collections;

public class VECTOR3_MANAGER_ : MonoBehaviour {

    // active_Mode_Options
    public enum active_Mode_Options {
        anchor, // anchor   - place/delete blocks
        link,   // link     - add/remove polygonlinks
    };
    public active_Mode_Options active_Manager_Mode;

    public void FUNCTION_switchModeToAnchor() {
        // anchor   - place/delete blocks
        // link     - add/remove polygonlinks
        active_Manager_Mode = active_Mode_Options.anchor;
    }

    public void FUNCTION_switchModeToLink() {
        // anchor   - add/remove blocks
        // link     - add/remove polygonlinks
        active_Manager_Mode = active_Mode_Options.link;
    }

    public void FUNCTION_reportVectorInformation(Vector3 vector, GameObject objectToIdentify) {
        if (active_Manager_Mode.Equals(active_Mode_Options.anchor)) {
            // objectToIdentify.transform.position;

        } else if (active_Manager_Mode.Equals(active_Mode_Options.link)) {

        }

        //   void updateName() {
        //
        //       string positionName = this.transform.position + "";
        //       string switchedNegativeName = positionName.Replace("-", "n");
        //       string removeLeftBracket = switchedNegativeName.Replace("(", "");
        //       string removeRightBracket = removeLeftBracket.Replace(")", "");
        //       string removeZero = removeRightBracket.Replace(".0", "");
        //       string replacecomma = removeZero.Replace(",", "-");
        //       string postName = replacecomma.Replace(" ", "");
        //       this.gameObject.name = "Anchor-" + postName;
        //   }
    }
}