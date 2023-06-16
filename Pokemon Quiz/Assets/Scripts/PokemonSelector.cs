using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private PokemonBuilder PokemonBuilder;
    void Start()
    {
        int index = Random.Range(0, 151);
        Texture2D imageT = PokemonBuilder.gen1.pokemonFinalList[index].image;
        image.sprite = Sprite.Create(imageT, new Rect(0, 0, imageT.width, imageT.height), new Vector2(0.5f, 0.5f));
    }
}
