using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonListsManager : MonoBehaviour
{
    private const int Gen1 = 152;
    private const int Gen2 = 252;
    private const int Gen3 = 387;
    private const int gen4 = 494;
    private const int Gen5 = 650;
    private const int Gen6 = 722;
    private const int Gen7 = 808;
    private const int Gen8 = 899;
    private const int LegendsArceus = 906;
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
            if (dataList.Count == 0)
            {
                LoadAllSaveLowest(dataList);
                return;
            }
            switch (dataList[0].no)
            {
                case < Gen1:
                    PokemonDataSave.SaveListAsJson(dataList, "gen1Progress.json");
                    break;
                case < Gen2:
                    PokemonDataSave.SaveListAsJson(dataList, "gen2Progress.json");
                    break;
                case < Gen3:
                    PokemonDataSave.SaveListAsJson(dataList, "gen3Progress.json");
                    break;
                case < gen4:
                    PokemonDataSave.SaveListAsJson(dataList, "gen4Progress.json");
                    break;
                case < Gen5:
                    PokemonDataSave.SaveListAsJson(dataList, "gen5Progress.json");
                    break;
                case < Gen6:
                    PokemonDataSave.SaveListAsJson(dataList, "gen6Progress.json");
                    break;
                case < Gen7:
                    PokemonDataSave.SaveListAsJson(dataList, "gen7Progress.json");
                    break;
                case < Gen8:
                    PokemonDataSave.SaveListAsJson(dataList, "gen8Progress.json");
                    break;
                case < LegendsArceus:
                    PokemonDataSave.SaveListAsJson(dataList, "legendsArceusProgress.json");
                    break;
                default:
                    PokemonDataSave.SaveListAsJson(dataList, "gen9Progress.json");
                    break;
            }
        }
    }

    private void LoadAllSaveLowest(List<PokemonInfo> dataList)
    {
        List<List<PokemonInfo>> temp = new List<List<PokemonInfo>>();

        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen1Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen2Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen3Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen4Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen5Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen6Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen7Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen8Progress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("legendsArceusProgress.json"));
        temp.Add(PokemonDataLoad.LoadJsonFile<PokemonInfo>("gen9Progress.json"));

        int tempCount = 9999;
        int tempIndex = 0;
        int listIndex = 0;

        foreach (List<PokemonInfo> list in temp)
        {
            if (list.Count < tempCount) { tempCount = list.Count; listIndex = tempIndex; }
            tempIndex++;
        }

        switch (listIndex)
        {
            case 0:
                PokemonDataSave.SaveListAsJson(dataList, "gen1Progress.json");
                break;
            case 1:
                PokemonDataSave.SaveListAsJson(dataList, "gen2Progress.json");
                break;
            case 2:
                PokemonDataSave.SaveListAsJson(dataList, "gen3Progress.json");
                break;
            case 3:
                PokemonDataSave.SaveListAsJson(dataList, "gen4Progress.json");
                break;
            case 4:
                PokemonDataSave.SaveListAsJson(dataList, "gen5Progress.json");
                break;
            case 5:
                PokemonDataSave.SaveListAsJson(dataList, "gen6Progress.json");
                break;
            case 6:
                PokemonDataSave.SaveListAsJson(dataList, "gen7Progress.json");
                break;
            case 7:
                PokemonDataSave.SaveListAsJson(dataList, "gen8Progress.json");
                break;
            case 8:
                PokemonDataSave.SaveListAsJson(dataList, "legendsArceusProgress.json");
                break;
            case 9:
                PokemonDataSave.SaveListAsJson(dataList, "gen9Progress.json");
                break;
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
