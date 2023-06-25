using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionsConfig
{
    public bool[] genToggles = new bool[10] { true, true, true, true, true, true, true, true, true, true };
    public bool silhouettes = true;
    public bool togglesEnabled = true;
    public int toggleCount = 10;
    public float threshold = 0.95f;
}
