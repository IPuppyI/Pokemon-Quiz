using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class PokemonListsManager : MonoBehaviour
{
    private PokemonLists dataLists = new PokemonLists(empty:true);
    private List<PokemonInfo> references = new List<PokemonInfo>();
    private GameManager gm;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        gm = FindAnyObjectByType<GameManager>();
    }

    public void AddList(string key, List<PokemonInfo> dataList)
    {
        dataLists.pokemonGenLists[key] = dataList;
        references.AddRange(dataList);
    }
    
    public void RemoveItem(int no)
    {
        references.RemoveAll(x => x.no == no);

        foreach (var dataList in dataLists.pokemonGenLists)
        {
            for (int i = 0; i < dataList.Value.Count; i++)
            {
                if (dataList.Value[i] != null && dataList.Value[i].no == no)
                {
                    dataList.Value.Remove(dataList.Value[i]);
                }
            }
        }
    }
    
    public PokemonInfo SearchItem(int index)
    {
        if (index >= 0 && index < references.Count)
        {
            return references[index];
        }

        return null;
    }

    public void SaveCurrentLists()
    {
        /*foreach (var dataList in dataLists.pokemonGenLists)
        {
            switch (dataList.Key)
            {
                case "Gen1":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[0]);
                    break;
                case "Gen2":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[1]);
                    break;
                case "Gen3":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[2]);
                    break;
                case "Gen4":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[3]);
                    break;
                case "Gen5":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[4]);
                    break;
                case "Gen6":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[5]);
                    break;
                case "Gen7":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[6]);
                    break;
                case "Gen8":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[7]);
                    break;
                case "Gen9":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[8]);
                    break;
                case "LegendsArceus":
                    PokemonDataManager.Save(dataList.Value, Filenames.FileNames[9]);
                    break;
                default:
                    break;
            }
        }*/

        foreach (var list in dataLists.pokemonGenLists)
        {
            gm.dataLists.pokemonGenLists[list.Key] = list.Value;
        }
        PokemonDataManager.Save(gm.dataLists, Filenames.FileNames[0]);
    }

    public void Clear()
    {
        dataLists = new PokemonLists(empty:true);
        references = new List<PokemonInfo>();
    }
    public int GetReferencesCount()
    {
        return references.Count;
    }
}
