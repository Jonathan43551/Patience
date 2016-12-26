using UnityEngine;
using System.Collections;
using System;
using Zenject;

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

    [Inject]
    [SerializeField]
    POSITION_ positionReference;


    public void FUNCTION_reportVectorInformation(Vector3 vector, GameObject objectToIdentify) {
        if (active_Manager_Mode.Equals(active_Mode_Options.anchor)) {
            // objectToIdentify.transform.position;
            //FUNCTION_reportVectorInformation
            Debug.Log(" _^^_ : VECTOR3_MANAGER_ : reportVectorInformation | anchor : " + vector);
            
            //objectToIdentify.POSI
        } else if (active_Manager_Mode.Equals(active_Mode_Options.link)) {
            Debug.Log(" _^^_ : VECTOR3_MANAGER_ : reportVectorInformation | link : " + vector);

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



    public void FUNCTION_ask_For_Position_and_GameObject() {
        // anchor factory. FUNCTION_sendPosition_and_GameObject_To_VECTOR3manager()
        positionReference.FUNCTION_sendPositionAndGameObjectToVECTOR3manager();
    }

    internal void FUNCTION_triageInstantiatedObject(object instantiatedObject) {
        Debug.Log(" _^^_ : VECTOR3_MANAGER_ : triageInstantiatedObject : " + instantiatedObject);
     

        // https://github.com/modesttree/Zenject/blob/master/Documentation/SubContainers.md#creating-game-object-contexts-dynamically-with-parameters
        // i want to use a zenject factory, i think this could possibly maybe work
        // i want to pass the new object to the factory so it creates a tracking object reference in the factory
    }
}