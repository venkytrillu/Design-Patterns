using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantData info;
    SetPlantInfo plantInfo;

    private void Start()
    {
        plantInfo = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown()
    {
        plantInfo.OpenPlantPanel();
        plantInfo.plantName.text = info.PlantName;
        plantInfo.threatLevel.text = info.ThreadName.ToString();
        plantInfo.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag=="Player" && info.ThreadName.ToString()=="High")
        {
            CharacterController.dead = true;
            plantInfo.OpenDiedPanel();
        }
    }


}//class
