using System;
using UnityEngine;
using Zenject;

public class FORGE_ : MonoBehaviour { 
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
    }

    public Rigidbody[] _RigidBody_Options;

    private int _RigidBody_Counter = 0;
    private int _RigidBody_CycleCounter = 0;



    // FUNCTION_generateRigidbody
    public void FUNCTION_generateRigidbody(Vector3 forgeGenerationPoint) {
        if (_RigidBody_Counter < _RigidBody_Options.Length - 1 ) {
            _RigidBody_Counter++;
            Debug.Log("FUNCTION_generateRigidbody :_RigidBody_Counter " + _RigidBody_Counter);
            object instantiatedObject = Instantiate(_RigidBody_Options[_RigidBody_CycleCounter], (forgeGenerationPoint), transform.rotation);
           
            Debug.Log("IF" + _RigidBody_CycleCounter);
        } else {
            _RigidBody_Counter = 0;
            object instantiatedObject = Instantiate(_RigidBody_Options[_RigidBody_CycleCounter], (forgeGenerationPoint), transform.rotation);
            Debug.Log("FUNCTION_generateRigidbody : _RigidBody_Options[ " + _RigidBody_CycleCounter + "]");
            
            Debug.Log("ELSE" + _RigidBody_CycleCounter);
            if(_RigidBody_CycleCounter < _RigidBody_Options.Length - 1) {
                _RigidBody_CycleCounter++;
            } else {
                _RigidBody_CycleCounter = 0;
            }
            

        }
    }

    public Vector3 U_generateBlock;
    public Vector3 J_generateBlock;
    public Vector3 M_generateBlock;

    public void FUNCTION_checkForInput() {
       if (Input.GetKey(KeyCode.U)) {
           FUNCTION_generateRigidbody(U_generateBlock);
       }
       
       if (Input.GetKey(KeyCode.J)) {
           FUNCTION_generateRigidbody(J_generateBlock);
       }
       
       if (Input.GetKey(KeyCode.M)) {
           FUNCTION_generateRigidbody(M_generateBlock);
       }
    }
}