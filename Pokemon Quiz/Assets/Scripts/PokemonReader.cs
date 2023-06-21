using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PokemonReader : MonoBehaviour
{
    [SerializeField] private PokemonFinalList gen1;
    [SerializeField] private PokemonFinalList gen2;
    [SerializeField] private PokemonFinalList gen3;
    [SerializeField] private PokemonFinalList gen4;
    [SerializeField] private PokemonFinalList gen5;
    [SerializeField] private PokemonFinalList gen6;
    [SerializeField] private PokemonFinalList gen7;
    [SerializeField] private PokemonFinalList gen8;
    [SerializeField] private PokemonFinalList gen9;
    [SerializeField] private PokemonFinalList legendsArceus;
    [SerializeField] private TextAsset gen1Json;
    [SerializeField] private TextAsset gen2Json;
    [SerializeField] private TextAsset gen3Json;
    [SerializeField] private TextAsset gen4Json;
    [SerializeField] private TextAsset gen5Json;
    [SerializeField] private TextAsset gen6Json;
    [SerializeField] private TextAsset gen7Json;
    [SerializeField] private TextAsset gen8Json;
    [SerializeField] private TextAsset gen9Json;
    [SerializeField] private TextAsset legendsArceusJson;

    void Start()
    {
        LoadLists();
    }

    private void LoadLists()
    {
        if (!string.IsNullOrEmpty(gen1Json.text))
        {
            gen1 = JsonUtility.FromJson<PokemonFinalList>(gen1Json.text);
        }

        if (!string.IsNullOrEmpty(gen2Json.text))
        {
            gen2 = JsonUtility.FromJson<PokemonFinalList>(gen2Json.text);
        }

        if (!string.IsNullOrEmpty(gen3Json.text))
        {
            gen3 = JsonUtility.FromJson<PokemonFinalList>(gen3Json.text);
        }

        if (!string.IsNullOrEmpty(gen4Json.text))
        {
            gen4 = JsonUtility.FromJson<PokemonFinalList>(gen4Json.text);
        }

        if (!string.IsNullOrEmpty(gen5Json.text))
        {
            gen5 = JsonUtility.FromJson<PokemonFinalList>(gen5Json.text);
        }

        if (!string.IsNullOrEmpty(gen6Json.text))
        {
            gen6 = JsonUtility.FromJson<PokemonFinalList>(gen6Json.text);
        }

        if (!string.IsNullOrEmpty(gen7Json.text))
        {
            gen7 = JsonUtility.FromJson<PokemonFinalList>(gen7Json.text);
        }

        if (!string.IsNullOrEmpty(gen8Json.text))
        {
            gen8 = JsonUtility.FromJson<PokemonFinalList>(gen8Json.text);
        }

        if (!string.IsNullOrEmpty(gen9Json.text))
        {
            gen9 = JsonUtility.FromJson<PokemonFinalList>(gen9Json.text);
        }

        if (!string.IsNullOrEmpty(legendsArceusJson.text))
        {
            legendsArceus = JsonUtility.FromJson<PokemonFinalList>(legendsArceusJson.text);
        }
    }

    [System.Serializable]
    public class PokemonFinalList
    {
        public List<PokemonFinal> pokemonFinalList = new List<PokemonFinal>();
    }
}

[System.Serializable]
public class PokemonFinal
{
    public Texture2D image;
    public int no;
    public string name;
}
