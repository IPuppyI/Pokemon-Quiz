using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonReader : MonoBehaviour
{
    /*[SerializeField] private TextAsset gen1;
    [SerializeField] private TextAsset gen2;
    [SerializeField] private TextAsset gen3;
    [SerializeField] private TextAsset gen4;
    [SerializeField] private TextAsset gen5;
    [SerializeField] private TextAsset gen6;
    [SerializeField] private TextAsset gen7;
    [SerializeField] private TextAsset gen8;
    [SerializeField] private TextAsset gen9;
    [SerializeField] private TextAsset legendsArceus;*/
    [SerializeField] private TextAsset pokemonInfo;

    public PokemonLists dataLists = new PokemonLists();

    void Awake()
    {
        SetLists();
    }

    public void SetLists()
    {
        /*dataLists.pokemonGenLists["Gen1"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen1.text);
        dataLists.pokemonGenLists["Gen2"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen2.text);
        dataLists.pokemonGenLists["Gen3"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen3.text);
        dataLists.pokemonGenLists["Gen4"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen4.text);
        dataLists.pokemonGenLists["Gen5"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen5.text);
        dataLists.pokemonGenLists["Gen6"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen6.text);
        dataLists.pokemonGenLists["Gen7"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen7.text);
        dataLists.pokemonGenLists["Gen8"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen8.text);
        dataLists.pokemonGenLists["Gen9"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(gen9.text);
        dataLists.pokemonGenLists["LegendsArceus"] = JsonConvert.DeserializeObject<List<PokemonInfo>>(legendsArceus.text);*/
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
