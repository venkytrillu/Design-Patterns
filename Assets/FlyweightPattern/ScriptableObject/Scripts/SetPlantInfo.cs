using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlantInfo : MonoBehaviour
{
    public GameObject plantInfoPanel;
    public GameObject plantIcon;
    public Text plantName;
    public Text threatLevel;
    public GameObject DiedPanel;
    public void OpenPlantPanel()
    {
        plantInfoPanel.SetActive(true);
    }

    public void ClosePlantPanel()
    {
        plantInfoPanel.SetActive(false);
    }

    public void OpenDiedPanel()
    {
        DiedPanel.SetActive(true);
    }

    public void CloseDiedPanel()
    {
        DiedPanel.SetActive(false);
    }

    public void LoadScene()
    {
        CharacterController.dead = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("World");
    }

}// class
