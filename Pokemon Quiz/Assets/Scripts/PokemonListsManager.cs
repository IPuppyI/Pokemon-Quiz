using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PokemonListsManager : MonoBehaviour
{
    /*private const int Gen1 = 152;
    private const int Gen2 = 252;
    private const int Gen3 = 387;
    private const int Gen4 = 494;
    private const int Gen5 = 650;
    private const int Gen6 = 722;
    private const int Gen7 = 808;
    private const int Gen8 = 899;
    private const int LegendsArceus = 906;*/
    private PokemonLists dataLists = new PokemonLists(empty:true);
    private List<PokemonInfo> references = new List<PokemonInfo>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
        foreach (var dataList in dataLists.pokemonGenLists)
        {
            /*if (dataList.Count == 0)
            {
                //LoadAllSaveLowest(dataList);
                return;
            }*/
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
            }
        }
    }

    /*private void LoadAllSaveLowest(List<PokemonInfo> dataList)
    {
        List<List<PokemonInfo>> temp = new List<List<PokemonInfo>>();

        temp.Add(PokemonDataManager.Load("gen1Progress.json"));
        temp.Add(PokemonDataManager.Load("gen2Progress.json"));
        temp.Add(PokemonDataManager.Load("gen3Progress.json"));
        temp.Add(PokemonDataManager.Load("gen4Progress.json"));
        temp.Add(PokemonDataManager.Load("gen5Progress.json"));
        temp.Add(PokemonDataManager.Load("gen6Progress.json"));
        temp.Add(PokemonDataManager.Load("gen7Progress.json"));
        temp.Add(PokemonDataManager.Load("gen8Progress.json"));
        temp.Add(PokemonDataManager.Load("legendsArceusProgress.json"));
        temp.Add(PokemonDataManager.Load("gen9Progress.json"));

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
                PokemonDataManager.Save(dataList, "gen1Progress.json");
                break;
            case 1:
                PokemonDataManager.Save(dataList, "gen2Progress.json");
                break;
            case 2:
                PokemonDataManager.Save(dataList, "gen3Progress.json");
                break;
            case 3:
                PokemonDataManager.Save(dataList, "gen4Progress.json");
                break;
            case 4:
                PokemonDataManager.Save(dataList, "gen5Progress.json");
                break;
            case 5:
                PokemonDataManager.Save(dataList, "gen6Progress.json");
                break;
            case 6:
                PokemonDataManager.Save(dataList, "gen7Progress.json");
                break;
            case 7:
                PokemonDataManager.Save(dataList, "gen8Progress.json");
                break;
            case 8:
                PokemonDataManager.Save(dataList, "legendsArceusProgress.json");
                break;
            case 9:
                PokemonDataManager.Save(dataList, "gen9Progress.json");
                break;
        }
    }*/

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
