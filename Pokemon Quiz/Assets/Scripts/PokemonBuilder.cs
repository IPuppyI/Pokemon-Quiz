using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class PokemonBuilder : MonoBehaviour
{
    [SerializeField] private JsonReader jsonReader;
    List<Texture2D> images = new List<Texture2D>();
    [SerializeField] public PokemonFinalList gen1;
    [SerializeField] public PokemonFinalList gen2;
    [SerializeField] public PokemonFinalList gen3;
    [SerializeField] public PokemonFinalList gen4;
    [SerializeField] public PokemonFinalList gen5;
    [SerializeField] public PokemonFinalList gen6;
    [SerializeField] public PokemonFinalList gen7;
    [SerializeField] public PokemonFinalList gen8;
    [SerializeField] public PokemonFinalList gen9;
    [SerializeField] public PokemonFinalList legendsArceus;

    void Start()
    {
        GetImages();
        CreateLists();
    }

    private void GetImages()
    {
        string name;
        string path;
        for (int i = 1; i < 1011; i++)
        {
            if (i < 10)
            {
                name = "00" + i;
            }
            else if (i < 100)
            {
                name = "0" + i;
            }
            else
            {
                name = "" + i;
            }
            Texture2D image = new Texture2D(1, 1);
            path = "Assets/Images/Pokemon_Images/" + name + ".png";
            byte[] bytes = File.ReadAllBytes(path);
            image.LoadImage(bytes);
            images.Add(image);
        }
    }

    private void CreateLists()
    {
        int i = 0;
        foreach (JsonReader.PokemonList pokemonList in jsonReader.pokemonLists.pokemonLists)
        {
            foreach(JsonReader.PokemonInfo pokemon in pokemonList.Pokemon)
            {
                PokemonFinal pokemonFinal = new PokemonFinal(pokemon.no, pokemon.name, images.ElementAt(i));
                switch (pokemon.no)
                {
                    case < 152:
                        gen1.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 252:
                        gen2.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 387:
                        gen3.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 494:
                        gen4.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 650:
                        gen5.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 722:
                        gen6.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 808:
                        gen7.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 899:
                        gen8.pokemonFinalList.Add(pokemonFinal);
                        break;
                    case < 906:
                        legendsArceus.pokemonFinalList.Add(pokemonFinal);
                        break;
                    default:
                        gen9.pokemonFinalList.Add(pokemonFinal);
                        break;
                }
                i++;
            }
        }
        
    }

    [System.Serializable]
    public class PokemonFinal
    {
        public Texture2D image;
        public int no;
        public string name;

        public PokemonFinal(int noT, string nameT, Texture2D imageT)
        {
            no = noT;
            name = nameT;
            image = imageT;
        }
    }

    [System.Serializable]
    public class PokemonFinalList
    {
        public List<PokemonFinal> pokemonFinalList;
    }
}
