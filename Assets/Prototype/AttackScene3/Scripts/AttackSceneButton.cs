using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSceneButton : MonoBehaviour
{

    public GameObject RevengeButtonPanel;
 

    //this function Exit the atatck scene and goes to the player main Scene 
    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestSetup");
    }

    //This enables the panel when Revenge button is Pressed
    public void RevengePanel()
    {

        if (RevengeButtonPanel != null)
        {
            RevengeButtonPanel.SetActive(true);
        }
    }

    //This close the Revenge Panel when close button Pressed
    public void RevengeCloseButton()
    {
        if (RevengeButtonPanel != null)
        {
            RevengeButtonPanel.SetActive(false);
        }
    }

}
