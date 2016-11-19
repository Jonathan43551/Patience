using UnityEngine;
using Zenject;

public class GRAVITY_INSTALLER : MonoInstaller<GRAVITY_INSTALLER> {

    [SerializeField]
    public Vector3 gravityValue;


    //   // this vector3 will be applied to all bodies in the scene
    //   public Vector3 vector3_Gravity_Value_To_Set { get; set; }
    //
    //   // this function will reset gravity to 0,0,0, then apply 'new_Vector3_Gravity_Value_To_Set'
    //   public void reset_To_Zero_Gravity()
    //   {
    //       Physics.gravity = new Vector3(0, 0, 0) + vector3_Gravity_Value_To_Set;
    //       //Debug.Log(Physics.gravity);



    public override void InstallBindings()
    {
        Container.Bind<GRAVITY_INTERFACE>().To<GRAVITY_>().AsSingle().NonLazy();

    }

    


}
