using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="plantdata",menuName ="Plant Data",order =51)]
public class PlantData : ScriptableObject
{
    public enum THREAT
    {
        none,Low,Moderate,High
    }

    [SerializeField]
    private string plantName;
    [SerializeField]
    private THREAT plantThreat;
    [SerializeField]
    private Texture icon;

    #region Public Properties
    public string PlantName
    {
        get
        {
            return plantName;
        }
    }
    public THREAT ThreadName
    {
        get
        {
            return plantThreat;
        }
    }
    public Texture Icon
    {
        get
        {
            return icon;
        }
    }
    #endregion

}//class
