using UnityEngine;
using System.Collections;
using Zenject;

public class POSITION_ : MonoBehaviour {
    [Inject]
    VECTOR3_MANAGER_ vector3ManagerReference;

    // this script will work alongside ANCHOR_ to help with management of anchors in space
    // https://en.wikipedia.org/wiki/Mooring_(watercraft)

    // how can we facilitate communication with our anchor friends?

    // it would be really nice to be able to send the entire vector3
    // something else will need to triage

    // this script will listen for position changes and 
    // when prompted, will send it's vector 3 information to the ANCHOR_communicator_


    public void FUNCTION_assignVector3Manager(VECTOR3_MANAGER_ vector3Manager) {
        vector3ManagerReference = vector3Manager;
        Debug.Log(" ^v^v position_ : assignVector3Manager: " + vector3Manager.name);
    }


	public void FUNCTION_sendPositionAndGameObjectToVECTOR3manager() {
        vector3ManagerReference.FUNCTION_reportVectorInformation( gameObject.transform.position, gameObject );
        Debug.Log(" ^v^v position_ : reportToVECTOR3manager: " + gameObject.transform.position);
    }

  // public void Awake() {
  //     Debug.Log(" .. position_ : vector3ManagerReference: " + vector3ManagerReference);
  //     if (Input.GetKey(KeyCode.C)) {
  //         FUNCTION_sendPositionAndGameObjectToVECTOR3manager();
  //     }
  // }
}

