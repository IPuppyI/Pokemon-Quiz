using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PokemonListsManager pokemonListsManager;
    private JsonReader jsonReader;
    [SerializeField] private string[] fileNames;
    private OptionsConfig optionsConfig;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectOfType<JsonReader>() != null)
        {
            jsonReader = FindObjectOfType<JsonReader>();
        }
        if (FindObjectOfType<PokemonListsManager>() != null)
        {
            pokemonListsManager = FindObjectOfType<PokemonListsManager>();
        }
        OptionsLoad.Load();
        optionsConfig = OptionsLoad.GetOptionsConfig();
        ReorganizeActiveGens();
        pokemonListsManager.SaveCurrentLists();
    }

    public void ReorganizeActiveGens()
    {
        for (int i = 0; i < 10; i++)
        {
            if (optionsConfig.genToggles[i] == true)
            {
                if (PokemonDataLoad.LoadJsonFile<PokemonInfo>(fileNames[i]) != null)
                {
                    pokemonListsManager.AddList(PokemonDataLoad.LoadJsonFile<PokemonInfo>(fileNames[i]));
                }
                else
                {
                    pokemonListsManager.AddList(jsonReader.pokemonLists.pokemonLists[i].Pokemon);
                }
            }
        }
    }

    public OptionsConfig GetOptionsConfig()
    {
        return optionsConfig;
    }
    public void SetOptionsConfig(OptionsConfig config)
    {
        optionsConfig = config;
    }
    public void SetThreshold(float thresh)
    {
        optionsConfig.threshold = thresh;
    }
}
