using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PokemonDataDelete
{
    public static void DeleteJsonFile(string fileName)
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
