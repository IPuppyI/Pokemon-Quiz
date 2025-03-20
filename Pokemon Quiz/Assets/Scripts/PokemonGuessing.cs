using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class PokemonGuessing : MonoBehaviour
{
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private TextMeshProUGUI input;
    private float threshold;

    public bool CheckAnswer()
    {
        string pokemonName = pokemonSelector.GetPokemonInfo().name.ToLower().Trim();
        string inputText = input.text.ToLower().Trim();
        inputText = Regex.Replace(inputText, @"\W", "");
        pokemonName = Regex.Replace(pokemonName, @"\W", "");
        int distance = LevenshteinDistance.Calculate(inputText, pokemonName);
        return (CheckName(pokemonName, distance));
    }
    public void SetThreshold(float thresh)
    {
        threshold = (thresh / 100);
    }

    private bool CheckName(string name, int distance)
    {
        return (((float)name.Length - distance) / (float)name.Length) >= threshold;
    }
}
