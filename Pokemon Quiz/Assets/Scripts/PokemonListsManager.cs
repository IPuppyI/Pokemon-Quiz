using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonListsManager : MonoBehaviour
{
    private List<List<PokemonInfo>> dataLists = new List<List<PokemonInfo>>();
    private List<PokemonInfo> references = new List<PokemonInfo>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddList(List<PokemonInfo> dataList)
    {
        dataLists.Add(dataList);
        references.AddRange(dataList);
    }

    public void RemoveItem(int no)
    {
        references.RemoveAll(x => x.no == no);

        foreach (List<PokemonInfo> dataList in dataLists)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i] != null && dataList[i].no == no)
                {
                    dataList.Remove(dataList[i]);
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
        foreach (List<PokemonInfo> dataList in dataLists)
        {
            switch (dataList[0].no)
            {
                case < 152:
                    PokemonDataSave.SaveListAsJson(dataList, "gen1Progress.json");
                    break;
                case < 252:
                    PokemonDataSave.SaveListAsJson(dataList, "gen2Progress.json");
                    break;
                case < 387:
                    PokemonDataSave.SaveListAsJson(dataList, "gen3Progress.json");
                    break;
                case < 494:
                    PokemonDataSave.SaveListAsJson(dataList, "gen4Progress.json");
                    break;
                case < 650:
                    PokemonDataSave.SaveListAsJson(dataList, "gen5Progress.json");
                    break;
                case < 722:
                    PokemonDataSave.SaveListAsJson(dataList, "gen6Progress.json");
                    break;
                case < 808:
                    PokemonDataSave.SaveListAsJson(dataList, "gen7Progress.json");
                    break;
                case < 899:
                    PokemonDataSave.SaveListAsJson(dataList, "gen8Progress.json");
                    break;
                case < 906:
                    PokemonDataSave.SaveListAsJson(dataList, "legendsArceusProgress.json");
                    break;
                default:
                    PokemonDataSave.SaveListAsJson(dataList, "gen9Progress.json");
                    break;
            }
        }
    }

    public void Clear()
    {
        dataLists = new List<List<PokemonInfo>>();
        references = new List<PokemonInfo>();
    }

    public int GetReferencesCount()
    {
        return references.Count;
    }
}
