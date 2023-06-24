using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private PokemonImagesContainerSO pokemonImages;
    [SerializeField] private JsonReader pokemonData;
    private PokemonInfo pokemonInfo;
    private GameManager gameManager;
    private int index;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SelectPokemon();
    }

    public void SelectPokemon()
    {
        int index = GetIndex(gameManager.GetActiveGens());
        pokemonInfo = pokemonData.GetPokemonByNum(index);
        Debug.Log(index); //Remove this later
        Debug.Log(pokemonInfo.ToString()); //Remove this later
        GetImage(index);
    }

    private int GetIndex(List<Vector2> ranges)
    {
        int temp = Random.Range(0, ranges.Count);
        return Random.Range((int)ranges[temp].x, (int)ranges[temp].y + 1) - 1;
    }

    private void GetImage(int index)
    {
        Texture2D imageT = pokemonImages.pokemonImages[index];
        image.sprite = Sprite.Create(imageT, new Rect(0, 0, imageT.width, imageT.height), new Vector2(0.5f, 0.5f));
        if (gameManager.GetSilhouettesToggle())
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
