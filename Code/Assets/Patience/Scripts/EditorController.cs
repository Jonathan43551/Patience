using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[System.Serializable]
public class Mode
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class ModeColor
{
    public Color panelColor;
    public Color textColor;


}


public class EditorController : MonoBehaviour
{

    public Text[] buttonList;

    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    private int moveCount;


    public Mode BouyMode;
    public Mode LinkMode;
    public ModeColor activeModeColor;
    public ModeColor inactiveModeColor;

    public GameObject startInfo;

    public int CreatedObjectCounter = 0;







//    enum Direction { North, East, South, West };
//
 //  void Start()
 //  {
 //      Direction myDirection;
 //
 //      myDirection = Direction.North;
 //  }
//
//   Direction ReverseDirection(Direction dir)
//   {
//       if (dir == Direction.North)
//           dir = Direction.South;
//       else if (dir == Direction.South)
//           dir = Direction.North;
//       else if (dir == Direction.East)
//           dir = Direction.West;
//       else if (dir == Direction.West)
//           dir = Direction.East;
//
//       return dir;
//    }














    void SetModeColors(Mode newMode, Mode oldMode)
    {
        
  //     newMode.panel.color = activeModeColor.panelColor;
  //     newMode.text.color = activeModeColor.textColor;
  // 
  //     oldMode.panel.color = inactiveModeColor.panelColor;
  //     oldMode.text.color = inactiveModeColor.textColor;
    }
 //   void Awake()
 //   {
 //       //gameOverPanel.SetActive(false);
 //       moveCount = 0;
 //       //restartButton.SetActive(false);
 //
 //   }



    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;


 //     if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
 //     {
 //         GameOver(playerSide);
 //     }
 //     else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
 //     {
 //         GameOver(playerSide);
 //     }
 //     else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
 //     {
 //           GameOver(playerSide);
 //     }
 //     else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
 //     {
///           GameOver(playerSide);
 //     }
 //     else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
 //     {
 ///          GameOver(playerSide);
 //     }
 //     else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
 //     {
 //           GameOver(playerSide);
 //     }
 //     else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
 //     {
 //           GameOver(playerSide);
 //     }
 //     else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
 //     {
 //           GameOver(playerSide);
 //     }
 //     else if (moveCount >= 9)
 //     {
 //           GameOver("draw");
 //     }
 //     else
 //     {
 //         ChangeSides();
 //     }
 // }





//   void ChangeSides()
//   {
//       int colorSiderCounter =+ 0;  
//       
//       //playerSide = (playerSide == "X") ? "O" : "X";
//       //  if (playerSide == "X")
//       //  {
//             SetModeColors(BouyMode, LinkMode);
//       Debug.Log(colorSiderCounter);
//       //  }
//       //  else
//       //  {
//       //      SetModeColors(LinkMode, BouyMode);
//       //  
//       //  }
//
//
//   }

//    void GameOver(string winningPlayer)
//    {
//        SetGameOverText(selectionCountertext);


//        SetBoardInteractable(false);
//        restartButton.SetActive(true);
    }

 //   void SetGameOverText(string value)
 //   {
 //       gameOverPanel.SetActive(true);
 //       gameOverText.text = value;
 //   }


    public void RestartGame()
    {
        //       moveCount = 0;
        //       gameOverPanel.SetActive(false);

        //restartButton.SetActive(false);

        CreatedObjectCounter = 0;

        //      for (int i = 0; i < buttonList.Length; i++)
        //       {
        //           buttonList[i].text = "";
        //       }

        //SetModeColorsInactive();
        SetPlayerButtons(true);
        //startInfo.SetActive(true);

    }

    //   void SetBoardInteractable(bool toggle)
    //  {
    //       for (int i = 0; i < buttonList.Length; i++)
    //       {
    //buttonList[i].GetComponentInParent<Button>().interactable = toggle;
    //       }
    //   }

    public void ControllerButtonClick(string startingSide)
    {

    }






    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;



      //  selectionCounter += 1;

        //selectionCountertext = selectionCounter.ToString();
     //   if (playerSide == "X")
     //   {
        SetModeColors(BouyMode, LinkMode);
     //   }
     //   else
     //   {
     //       SetModeColors(LinkMode, BouyMode);
     //   }
     //
        StartGame();
    }

    void StartGame()
    {
//        SetBoardInteractable(true);
        //SetPlayerButtons(false);
        //startInfo.SetActive(false);
    }

    void SetPlayerButtons(bool toggle)
    {
        BouyMode.button.interactable = toggle;
        LinkMode.button.interactable = toggle;
    }

    void SetModeColorsInactive()
    {
        BouyMode.panel.color = inactiveModeColor.panelColor;
        BouyMode.text.color = inactiveModeColor.textColor;

        LinkMode.panel.color = inactiveModeColor.panelColor;
        LinkMode.text.color = inactiveModeColor.textColor;
    }

    



}