using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PokemonSelector pokemonSelector;
    private List<Vector2> activeGenerations = new List<Vector2>();
    [SerializeField] private Vector2[] generations;
    private OptionsConfig optionsConfig;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        OptionsLoad.Load();
        optionsConfig = OptionsLoad.GetOptionsConfig();
        ReorganizeActiveGens();
    }

    public void ReorganizeActiveGens()
    {
        List<Vector2> temp = new List<Vector2>();
        for (int i = 0; i < 10; i++)
        {
            if (optionsConfig.genToggles[i] == true)
            {
                temp.Add(generations[i]);
            }
        }
        activeGenerations = temp;
    }

    public OptionsConfig GetOptionsConfig()
    {
        return optionsConfig;
    }
    public List<Vector2> GetActiveGens()
    {
        return activeGenerations;
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
