using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset pokemonInfo;

    public PokemonLists dataLists = new PokemonLists();

    void Awake()
    {
        SetLists();
    }

    public void SetLists()
    {
        dataLists = JsonConvert.DeserializeObject<PokemonLists>(pokemonInfo.text);
    }
}

[System.Serializable]
public class PokemonLists
{
    public Dictionary<string, List<PokemonInfo>> pokemonGenLists;

    public PokemonLists(bool empty = false)
    {
        if (!empty)
        {
            pokemonGenLists = new Dictionary<string, List<PokemonInfo>>()
            {
                { "Gen1", new List <PokemonInfo>() },
                { "Gen2", new List <PokemonInfo>() },
                { "Gen3", new List <PokemonInfo>() },
                { "Gen4", new List <PokemonInfo>() },
                { "Gen5", new List <PokemonInfo>() },
                { "Gen6", new List <PokemonInfo>() },
                { "Gen7", new List <PokemonInfo>() },
                { "Gen8", new List <PokemonInfo>() },
                { "Gen9", new List <PokemonInfo>() },
                { "LegendsArceus", new List <PokemonInfo>() }
            };
        }
        else
        {
            pokemonGenLists = new Dictionary<string, List<PokemonInfo>>();
        }
    }
}
