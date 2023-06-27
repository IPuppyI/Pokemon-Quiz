using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject pokemonListsManager;
    void Start()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Instantiate(gameManager);
        }
        if(FindObjectOfType<PokemonListsManager>() == null)
        {
            Instantiate(pokemonListsManager);
        }
    }
}
