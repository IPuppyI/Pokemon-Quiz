using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemonInfo
{
    public int no { get; set; }
    public string name { get; set; }

    public PokemonInfo(int noT, string nameT)
    {
        no = noT;
        name = nameT;
    }
}