using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemonInfo
{
    public int no;
    public string name;

    public PokemonInfo(int noT, string nameT)
    {
        no = noT;
        name = nameT;
    }

    public string ToString() //Remove this later
    {
        return "Number: " + no + " Name: " + name;
    }
}