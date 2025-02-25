using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class PokemonDataManager
{
    public static void Save(List<PokemonInfo> list, string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("Pokemon Data saved to: " + filePath);
    }
    public static List<PokemonInfo> Load<PokemonInfo>(string fileName)
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
    public static void Delete(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Deleted JSON file: " + fileName);
        }
        else
        {
            Debug.LogError("JSON file not found: " + fileName);
        }
    }
}
