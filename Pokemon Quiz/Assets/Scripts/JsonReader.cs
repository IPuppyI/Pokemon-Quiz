using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset gen1;
    [SerializeField] private TextAsset gen2;
    [SerializeField] private TextAsset gen3;
    [SerializeField] private TextAsset gen4;
    [SerializeField] private TextAsset gen5;
    [SerializeField] private TextAsset gen6;
    [SerializeField] private TextAsset gen7;
    [SerializeField] private TextAsset gen8;
    [SerializeField] private TextAsset gen9;
    [SerializeField] private TextAsset legendsArceus;

    [System.Serializable]
    public class PokemonInfo
    {
        public int no;
        public string name;
    }

    [System.Serializable]
    public class PokemonList
    {
        public PokemonInfo[] Pokemon;
    }

    [System.Serializable]
    public class PokemonLists
    {
        public PokemonList[] pokemonLists = new PokemonList[10];
    }

    public PokemonLists pokemonLists = new PokemonLists();

    void Awake()
    {
        pokemonLists.pokemonLists[0] = JsonUtility.FromJson<PokemonList>(gen1.text);
        pokemonLists.pokemonLists[1] = JsonUtility.FromJson<PokemonList>(gen2.text);
        pokemonLists.pokemonLists[2] = JsonUtility.FromJson<PokemonList>(gen3.text);
        pokemonLists.pokemonLists[3] = JsonUtility.FromJson<PokemonList>(gen4.text);
        pokemonLists.pokemonLists[4] = JsonUtility.FromJson<PokemonList>(gen5.text);
        pokemonLists.pokemonLists[5] = JsonUtility.FromJson<PokemonList>(gen6.text);
        pokemonLists.pokemonLists[6] = JsonUtility.FromJson<PokemonList>(gen7.text);
        pokemonLists.pokemonLists[7] = JsonUtility.FromJson<PokemonList>(gen8.text);
        pokemonLists.pokemonLists[8] = JsonUtility.FromJson<PokemonList>(gen9.text);
        pokemonLists.pokemonLists[9] = JsonUtility.FromJson<PokemonList>(legendsArceus.text);
    }
}
