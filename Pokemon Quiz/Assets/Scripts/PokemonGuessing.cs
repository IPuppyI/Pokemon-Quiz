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
        int distance = LevenshteinDistance.Calculate(inputText, pokemonName);
        Debug.Log(pokemonName); //Remove this later
        Debug.Log(inputText); //Remove this later
        Debug.Log(distance); //Remove this later
        Debug.Log(pokemonName.Length); //Remove this later
        Debug.Log(inputText.Length); //Remove this later
        Debug.Log(pokemonName.Length - distance + "/" + pokemonName.Length); //Remove this later
        Debug.Log(((float)pokemonName.Length - distance) / (float)pokemonName.Length); //Remove this later
        if (((float)pokemonName.Length - distance / (float)pokemonName.Length) >= threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetThreshold(float thresh)
    {
        threshold = (thresh / 100);
    }
}
