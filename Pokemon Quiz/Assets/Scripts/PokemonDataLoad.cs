using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class PokemonDataLoad
{
    public static List<PokemonInfo> LoadJsonFile<PokemonInfo>(string fileName)
    {
        List<PokemonInfo> dataList = new List<PokemonInfo>();

        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            dataList = JsonConvert.DeserializeObject<List<PokemonInfo>>(json);
        }
        else
        {
            Debug.LogError("JSON file not found: " + fileName);
            return null;
        }

        return dataList;
    }
}
