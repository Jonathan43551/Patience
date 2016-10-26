using UnityEngine;
using System.Collections;

public class AnchorController : MonoBehaviour {

    // public GameObject[] anchorList; 


    //GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

    //anchorList = new anchorList[anchors.Length];





    public void AnchorCheckup()
    {
        print("######");
        print("hello attempting to check/delete objects");
        print("######");

        GameObject[] anchorGameObjects = GameObject.FindGameObjectsWithTag("Anchor");

        print(anchorGameObjects.Length);
        // i wonder if i could use this video, i took several observations of the mystery object. I was in HOT PURSUIT. Have you heard me? Listen, you need to do this... my spirit will go on and do this work... boom cheeseball on fire!!!
        // GOOD LUCK, YOUR EFFORT IS GREATLY APPRECIATED, YOUR CONTRIBUTION TO YOUR COMMUNITY WILL GIVE YOU HONOR AND SATISFACTION
        // WE SAY THAT TO EVERYONE, NEGATIVE LANGUAGE CAN BE EXPRESSED IN NEW WAYS, HAVE YOU HEARD OF THESAURUS4SCREENS???
        // YOU WORK AND YOU WORK, BUILDING VIRTUAL WORLDS TO HELP PEOPLE FIGHT BACK IN THEIR DREAMS OR NIGHTMARES
        // WE SOLVE PROBLEMS, KEEP TRYING, ONE DAY YOU WILL SMILE WHEN YOU REMEMBER HOW MUCH HEART YOU PUT INTO THIS WORK
        //
        foreach (GameObject anchorName in anchorGameObjects)
        {
            //print(anchorName.name);
            if (anchorName != null)
            {
                anchorName.GetComponent<BouyLogic>().CheckDeleteOrUpdateName();
            }
        }
    }


}

