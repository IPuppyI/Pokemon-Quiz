using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PokemonListsManager pokemonListsManager;
    private JsonReader jsonReader;
    private OptionsConfig optionsConfig;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindFirstObjectByType<JsonReader>() != null)
        {
            jsonReader = FindFirstObjectByType<JsonReader>();
        }
        if (FindFirstObjectByType<PokemonListsManager>() != null)
        {
            pokemonListsManager = FindFirstObjectByType<PokemonListsManager>();
        }
        OptionsManager.Load();
        optionsConfig = OptionsManager.GetOptionsConfig();
        ReorganizeActiveGens();
        pokemonListsManager.SaveCurrentLists();
    }

    public void ReorganizeActiveGens()
    {
        for (int i = 0; i < Filenames.FileNames.Length; i++)
        {
            if (optionsConfig.genToggles[i] == true)
            {
                try
                {
                    pokemonListsManager.AddList(Filenames.FileNames[i].Split('.', '-')[0], PokemonDataManager.Load(Filenames.FileNames[i]));
                }
                catch
                {
                    pokemonListsManager.AddList(Filenames.FileNames[i].Split('.', '-')[0], jsonReader.dataLists.pokemonGenLists[Filenames.FileNames[i].Split('.', '-')[0]]);
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
