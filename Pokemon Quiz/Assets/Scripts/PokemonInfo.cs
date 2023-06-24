using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemonInfo
{
    public int no;
    public string name;

    public string ToString()
    {
        return "Number: " + no + " Name: " + name;
    }
}