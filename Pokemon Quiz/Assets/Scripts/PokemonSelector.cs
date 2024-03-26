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

    private const int MissingNo = 1010;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        pokemonListsManager = FindFirstObjectByType<PokemonListsManager>();
        SelectPokemon();
    }

    public void SelectPokemon()
    {
        int index = GetIndex();
        if (index == -1)
        {
            GetImage(MissingNo);
            image.color = Color.white;
            pokemonInfo = new PokemonInfo(-1, "OutOfPokemon");
        }
        else 
        { 
            pokemonInfo = pokemonListsManager.SearchItem(index);
            GetImage(pokemonInfo.no - 1);
        }
    }

    private int GetIndex()
    {
        if (pokemonListsManager.GetReferencesCount() > 0)
        {
            return Random.Range(0, pokemonListsManager.GetReferencesCount());
        }
        else
        {
            return -1;
        }
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
