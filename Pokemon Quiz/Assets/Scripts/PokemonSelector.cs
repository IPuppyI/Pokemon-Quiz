using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private PokemonImagesContainerSO pokemonImages;
    private PokemonInfo pokemonInfo;
    private GameManager gameManager;
    private PokemonListsManager pokemonListsManager;
    private int index;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pokemonListsManager = FindObjectOfType<PokemonListsManager>();
        SelectPokemon();
    }

    public void SelectPokemon()
    {
        int index = GetIndex();
        pokemonInfo = pokemonListsManager.SearchItem(index);
        Debug.Log(index); //Remove this later
        Debug.Log(pokemonInfo.ToString()); //Remove this later
        GetImage(pokemonInfo.no - 1);
    }

    private int GetIndex()
    {
        return Random.Range(0, pokemonListsManager.GetReferencesCount());
    }

    private void GetImage(int index)
    {
        Texture2D imageT = pokemonImages.pokemonImages[index];
        image.sprite = Sprite.Create(imageT, new Rect(0, 0, imageT.width, imageT.height), new Vector2(0.5f, 0.5f));
        if (gameManager.GetOptionsConfig().silhouettes)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
    }

    public PokemonInfo GetPokemonInfo()
    {
        return pokemonInfo;
    }
}
