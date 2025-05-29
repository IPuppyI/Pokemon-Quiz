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
