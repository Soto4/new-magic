using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewdataHolder", menuName ="Data/New Data Holder")]
[System.Serializable]
public class DataHolder : ScriptableObject
{
    public List<Scene01> scenes;
}
