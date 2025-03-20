using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PokemonListsManager pokemonListsManager;
    [SerializeField] private Toggles toggles;
    [SerializeField] private PokemonGuessing pokemonGuessing;
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Slider thresholdSlider;
    [SerializeField] private TextMeshProUGUI sliderValueText;
    [SerializeField] private Image image;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject gens;
    [SerializeField] private GameObject extra;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject outOfPokemon;
    [SerializeField] private ConfirmationWindow confirmationWindow;
    private bool caught;
    private bool checking;

    private string FileName;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        pokemonListsManager = FindFirstObjectByType<PokemonListsManager>();
        if (gameManager == null)
        {
            return;
        }
        if (toggles != null)
        {
            toggles.SetOptionsConfig(gameManager.GetOptionsConfig());
        }
        if (thresholdSlider != null)
        {
            thresholdSlider.value = gameManager.GetOptionsConfig().threshold;
        }
        if (pokemonGuessing != null)
        {
            pokemonGuessing.SetThreshold(gameManager.GetOptionsConfig().threshold);
        }
    }

    private void OnEnable()
    {
        caught = false;
        checking = false;
    }

    private void Update()
    {
        if (thresholdSlider != null)
        {
            sliderValueText.text = "" + (thresholdSlider.value / 100);
        }
        if (pokemonSelector != null)
        {
            if (pokemonSelector.GetPokemonInfo().no == -1 && !caught)
            {
                outOfPokemon.SetActive(true);
                caught = true;
            }
        }
    }

    #region Main Menu Buttons
    public void OptionsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayButtion()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Options Menu Buttons
    public void BackButton()
    {
        gameManager.SetOptionsConfig(toggles.GetOptionsConfig());
        gameManager.SetThreshold(thresholdSlider.value);
        OptionsManager.Save(gameManager.GetOptionsConfig(), "OptionsConfig.json");
        pokemonListsManager.Clear();
        gameManager.ReorganizeActiveGens();
        SceneManager.LoadScene(0);
    }
    public void GensBackButton()
    {
        gens.SetActive(false);
        main.SetActive(true);
    }
    public void ExtraBackButton()
    {
        extra.SetActive(false);
        main.SetActive(true);
    }
    public void ResetBackButton()
    {
        reset.SetActive(false);
        main.SetActive(true);
    }
    public void GensButton()
    {
        main.SetActive(false);
        gens.SetActive(true);
    }
    public void ExtraButton()
    {
        main.SetActive(false);
        extra.SetActive(true);
    }
    public void ResetButton()
    {
        main.SetActive(false);
        reset.SetActive(true);
    }
    #endregion

    #region Reset Menu Buttions

    public void ResetGen1Button()
    {
        OpenConfirmationWindow("This will delete your Gen 1 Pokemon data", Filenames.FileNames[0]);
    }
    public void ResetGen2Button()
    {
        OpenConfirmationWindow("This will delete your Gen 2 Pokemon data", Filenames.FileNames[1]);
    }
    public void ResetGen3Button()
    {
        OpenConfirmationWindow("This will delete your Gen 3 Pokemon data", Filenames.FileNames[2]);
    }
    public void ResetGen4Button()
    {
        OpenConfirmationWindow("This will delete your Gen 4 Pokemon data", Filenames.FileNames[3]);
    }
    public void ResetGen5Button()
    {
        OpenConfirmationWindow("This will delete your Gen 5 Pokemon data", Filenames.FileNames[4]);
    }
    public void ResetGen6Button()
    {
        OpenConfirmationWindow("This will delete your Gen 6 Pokemon data", Filenames.FileNames[5]);
    }
    public void ResetGen7Button()
    {
        OpenConfirmationWindow("This will delete your Gen 7 Pokemon data", Filenames.FileNames[6]);
    }
    public void ResetGen8Button()
    {
        OpenConfirmationWindow("This will delete your Gen 8 Pokemon data", Filenames.FileNames[7]);
    }
    public void ResetGen9Button()
    {
        OpenConfirmationWindow("This will delete your Gen 9 Pokemon data", Filenames.FileNames[8]);
    }
    public void ResetArceusButton()
    {
        OpenConfirmationWindow("This will delete your Legends Arceus Pokemon data", Filenames.FileNames[9]);
    }
    public void ResetAllButton()
    {
        OpenConfirmationWindow("This will delete ALL your Pokemon data", "All");
    }
    #endregion

    #region Play Screen Buttons
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
        yield return new WaitForSeconds(1f);
        wrong.SetActive(false);
    }
    private IEnumerator Right()
    {
        if (!checking)
        {
            checking = true;
            correct.SetActive(true);
            image.color = Color.white;
            yield return new WaitForSeconds(1f);
            correct.SetActive(false);
            inputText.text = "";
            pokemonListsManager.RemoveItem(pokemonSelector.GetPokemonInfo().no);
            pokemonListsManager.SaveCurrentLists();
            pokemonSelector.SelectPokemon();
            checking = false;
        }
    }
    #endregion

    #region Other
    public void YesButton()
    {
        DeleteData(FileName);
        confirmationWindow.yesButton.onClick.RemoveListener(YesButton);
        confirmationWindow.noButton.onClick.RemoveListener(NoButton);
        confirmationWindow.gameObject.SetActive(false);
        FileName = null;
        Debug.Log("Yes button clicked.");
    }
    public void NoButton()
    {
        confirmationWindow.yesButton.onClick.RemoveListener(YesButton);
        confirmationWindow.noButton.onClick.RemoveListener(NoButton);
        confirmationWindow.gameObject.SetActive(false);
        FileName = null;
        Debug.Log("No button clicked.");
    }
    public void OpenConfirmationWindow(string context, string fileName)
    {
        confirmationWindow.gameObject.SetActive(true);
        confirmationWindow.yesButton.onClick.AddListener(YesButton);
        confirmationWindow.noButton.onClick.AddListener(NoButton);
        confirmationWindow.contextText.text = context;
        FileName = fileName;
        Debug.Log("Confirmation window opened | " + FileName);
    }
    private void DeleteData(string file)
    {
        try
        {
            if (file == "All")
            {
                PokemonDataManager.Delete(Filenames.FileNames[0]);
                PokemonDataManager.Delete(Filenames.FileNames[1]);
                PokemonDataManager.Delete(Filenames.FileNames[2]);
                PokemonDataManager.Delete(Filenames.FileNames[3]);
                PokemonDataManager.Delete(Filenames.FileNames[4]);
                PokemonDataManager.Delete(Filenames.FileNames[5]);
                PokemonDataManager.Delete(Filenames.FileNames[6]);
                PokemonDataManager.Delete(Filenames.FileNames[7]);
                PokemonDataManager.Delete(Filenames.FileNames[8]);
                PokemonDataManager.Delete(Filenames.FileNames[9]);
            }
            else
            {
                PokemonDataManager.Delete(file);
                Debug.Log($"{file} deleted.");
            }
        }
        catch
        {
            Debug.Log($"{file} not deleted.");
        }
    }
    #endregion
}
