using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokemonGuessing : MonoBehaviour
{
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private TextMeshProUGUI input;
    private float threshold;

    public bool CheckAnswer()
    {
        string pokemonName = pokemonSelector.GetPokemonInfo().name.ToLower();
        string inputText = input.text.ToLower().Remove(input.text.Length - 1, 1);
        inputText = inputText.Replace(" ", "");
        pokemonName = pokemonName.Replace(" ", "");
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
