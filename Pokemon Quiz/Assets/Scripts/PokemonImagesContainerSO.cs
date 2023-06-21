using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokemonImages", menuName = "ScriptableObjects/PokemonImagesContainerSO")]
public class PokemonImagesContainerSO : ScriptableObject
{
    public List<Texture2D> pokemonImages = new List<Texture2D>();
}
