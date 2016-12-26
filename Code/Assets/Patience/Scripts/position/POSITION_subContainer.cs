//      using Zenject;
//      
//      public class POSITION_subContainer : IInitializable {
//          readonly POSITION_          positionReference;
//          readonly VECTOR3_MANAGER_   vector3ManagerReference;
//      
//          public POSITION_subContainer(POSITION_ injectedPositionReference, VECTOR3_MANAGER_ injectedVECTOR3ManagerReference) {
//              positionReference       = injectedPositionReference;
//              vector3ManagerReference = injectedVECTOR3ManagerReference;
//          }
//          
//          public void Initialize() {
//              positionReference.FUNCTION_assignVector3Manager(vector3ManagerReference);
//          }
//      }