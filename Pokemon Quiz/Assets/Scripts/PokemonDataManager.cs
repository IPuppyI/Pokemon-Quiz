using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class PokemonDataManager
{
    public static void Save(PokemonLists list, string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("Pokemon Data saved to: " + filePath);
    }
    public static PokemonLists Load(string fileName)
    {
        PokemonLists dataList;

        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        try
        {
            string json = File.ReadAllText(filePath);
            dataList = JsonConvert.DeserializeObject<PokemonLists>(json);
            return dataList;
        }
        catch
        {
            Debug.LogError("JSON file not found: " + fileName);
            return null;
        }
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
