using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject pokemonListsManager;
    void Start()
    {
        if (FindFirstObjectByType<GameManager>() == null)
        {
            Instantiate(gameManager);
        }
        if(FindFirstObjectByType<PokemonListsManager>() == null)
        {
            Instantiate(pokemonListsManager);
        }
    }
}
