using UnityEngine;

public class FORGE_ : MonoBehaviour { 
    // FUNCTION_triageWithCOSMO
    public int worldIdentifier = -509;
    public int transactionIdentifier = -500000;
    public void FUNCTION_triageWithCOSMO(string objectLocationTriageWithCOSMO)
    {
        Debug.Log(worldIdentifier + "^" + transactionIdentifier + objectLocationTriageWithCOSMO);
        transactionIdentifier++;
    }
    
    // FUNCTION_switchFORGE_Mode
    public enum ACTIVE_FORGE_Mode_Options
    {
        anchor,
        link,
    };
    public ACTIVE_FORGE_Mode_Options ACTIVE_FORGE_Mode_;

    public void FUNCTION_switchFORGE_Mode() {

        if (ACTIVE_FORGE_Mode_ == ACTIVE_FORGE_Mode_Options.anchor) {
            ACTIVE_FORGE_Mode_ = ACTIVE_FORGE_Mode_Options.link;
        } else {
            ACTIVE_FORGE_Mode_ = ACTIVE_FORGE_Mode_Options.anchor;
        }
        //Debug.Log(ACTIVE_FORGE_Mode_);
    }
    
    // FUNCTION_switchOption<identifier>
    public Rigidbody ACTIVE_FORGE_Rigidbody_;

    public Rigidbody _Rigidbody_OptionYellow;
    public Rigidbody _Rigidbody_OptionBlue;
    public Rigidbody _Rigidbody_OptionGreen;

    public void FUNCTION_switchOptionYellow() {
        ACTIVE_FORGE_Rigidbody_ = _Rigidbody_OptionYellow;
    }

    public void FUNCTION_switchOptionBlue() {
        ACTIVE_FORGE_Rigidbody_ = _Rigidbody_OptionBlue;
    }

    public void FUNCTION_switchOptionGreen() {
        ACTIVE_FORGE_Rigidbody_ = _Rigidbody_OptionGreen;
    }

    // FUNCTION_generateRigidbody
    public void FUNCTION_generateRigidbody(Vector3 forgeGenerationPoint) {
        Instantiate(ACTIVE_FORGE_Rigidbody_, (forgeGenerationPoint), transform.rotation);
    }
    
    public void FUNCTION_checkForInput() {
        if (Input.GetKey(KeyCode.U)) { // OptionYellow
            FUNCTION_switchOptionYellow();
            FUNCTION_generateRigidbody(new Vector3(transform.position.x,transform.position.y,transform.position.z));
        }

        if (Input.GetKey(KeyCode.J)) { // OptionBlue
            FUNCTION_switchOptionBlue();
            FUNCTION_generateRigidbody(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        }

        if (Input.GetKey(KeyCode.M)) { // OptionGreen
            FUNCTION_switchOptionGreen();
            FUNCTION_generateRigidbody(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        }
    }
}