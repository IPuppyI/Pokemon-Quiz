using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PokemonSelector pokemonSelector;
    private List<Vector2> activeGenerations = new List<Vector2>();
    [SerializeField] private Vector2[] generations;
    private bool[] genToggles = new bool[10] {true, true, true, true, true, true, true, true, true, true};
    private bool silhouettes = true;
    private int toggleCount = 10;
    private bool togglesEnabled = true;
    private float threshold = 0.95f;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (Vector2 range in generations)
        {
            activeGenerations.Add(range);
        }
    }

    public void ReorganizeActiveGens()
    {
        List<Vector2> temp = new List<Vector2>();
        for (int i = 0; i < 10; i++)
        {
            if (genToggles[i] == true)
            {
                temp.Add(generations[i]);
            }
        }
        activeGenerations = temp;
    }

    public bool[] GetGenToggles()
    {
        return genToggles;
    }
    public bool GetSilhouettesToggle()
    {
        return silhouettes;
    }
    public int GetToggleCount()
    {
        return toggleCount;
    }
    public bool GetTogglesEnabled()
    {
        return togglesEnabled;
    }
    public float GetThreshold()
    {
        return threshold;
    }
    public List<Vector2> GetActiveGens()
    {
        return activeGenerations;
    }
    public void SetGenToggles(bool[] gens)
    {
        genToggles = gens;
    }
    public void SetSilhouettesToggle(bool sil)
    {
        silhouettes = sil;
    }
    public void SetToggleCount(int count)
    {
        toggleCount = count;
    }
    public void SetTogglesEnabled(bool enabled)
    {
        togglesEnabled = enabled;
    }
    public void SetThreshold(float thresh)
    {
        threshold = thresh;
    }
}
