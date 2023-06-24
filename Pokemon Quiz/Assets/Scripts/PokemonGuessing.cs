using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokemonGuessing : MonoBehaviour
{
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private TextMeshProUGUI input;
    private float threshold = 0.95f;

    public bool CheckAnswer()
    {
        int i = 0;
        int numCorrect = 0;
        string pokemonName = pokemonSelector.GetPokemonInfo().name.ToLower();
        string inputText = input.text.ToLower();
        char[] temp = pokemonName.ToCharArray();
        foreach (char character in inputText)
        {
            if (i > pokemonName.Length - 1)
            {
                Debug.Log("Over Index"); //Remove this later
                break;
            }
            if (character.Equals(temp[i]))
            {
                numCorrect++;
            }
            i++;
        }
        Debug.Log(pokemonName); //Remove this later
        Debug.Log(inputText); //Remove this later
        Debug.Log(numCorrect + "/" + temp.Length); //Remove this later
        Debug.Log((float)numCorrect / (float)temp.Length); //Remove this later
        if (((float)numCorrect / (float)temp.Length) >= threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
