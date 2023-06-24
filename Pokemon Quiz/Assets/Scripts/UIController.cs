using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Toggles toggles;
    [SerializeField] private PokemonGuessing pokemonGuessing;
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Slider thresholdSlider;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            return;
        }
        if (toggles != null)
        {
            toggles.SetGenToggles(gameManager.GetGenToggles());
            toggles.SetSilhouettesToggle(gameManager.GetSilhouettesToggle());
            toggles.SetToggleCount(gameManager.GetToggleCount());
            toggles.SetTogglesEnabled(gameManager.GetTogglesEnabled());
        }
        if (thresholdSlider != null)
        {
            thresholdSlider.minValue = 0.75f;
            thresholdSlider.maxValue = 1f;
            thresholdSlider.value = gameManager.GetThreshold();
        }
        if (pokemonGuessing != null)
        {
            pokemonGuessing.SetThreshold(gameManager.GetThreshold());
        }
    }

    public void BackButton()
    {
        gameManager.SetGenToggles(toggles.GetGenToggles());
        gameManager.SetSilhouettesToggle(toggles.GetSilhouettesToggle());
        gameManager.SetToggleCount(toggles.GetToggleCount());
        gameManager.SetTogglesEnabled(toggles.GetTogglesEnabled());
        gameManager.SetThreshold(thresholdSlider.value);
        gameManager.ReorganizeActiveGens();
        SceneManager.LoadScene(0);
    }
    
    public void OptionsButton()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayButtion()
    {
        SceneManager.LoadScene(1);
    }

    public void SubmitButton()
    {
        if (pokemonGuessing.CheckAnswer())
        {
            StartCoroutine(Right());
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }

    public void PlayBackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SkipButton()
    {
        inputText.text = "";
        pokemonSelector.SelectPokemon();
    }

    private IEnumerator Wrong()
    {
        wrong.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(false);
    }
    private IEnumerator Right()
    {
        correct.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        correct.SetActive(false);
        inputText.text = "";
        pokemonSelector.SelectPokemon();
    }
}
