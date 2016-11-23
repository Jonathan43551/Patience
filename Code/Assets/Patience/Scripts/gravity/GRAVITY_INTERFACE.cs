using UnityEngine;
using System.Collections;

// MUSIC I am listening to while working
// [Hard Dance] - Stonebank - Be Alright (feat. EMEL) [Monstercat Release] 
// www.youtube.com/watch?v=X5a0tLjGOww

public interface GRAVITY_INTERFACE {

    // I want to be able to have any object change the gravity of a scene
    // https://docs.unity3d.com/ScriptReference/Physics-gravity.html

    // I need to have a way to control this from inside the game window and in the Unity editor
    // I want to use this script as an interface for that, going to use a single Vector3 instead of 3 int variables

    // this vector3 will be applied to all bodies in the scene
    Vector3 vector3_Gravity_Value_To_Set { get; set; }

    // this function will reset gravity to 0,0,0, then apply 'new_Vector3_Gravity_Value_To_Set'
    void reset_To_Zero_Gravity();



}
