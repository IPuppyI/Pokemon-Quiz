using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;

    private void Start()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            Instantiate(gameManager);
        }
    }
}
