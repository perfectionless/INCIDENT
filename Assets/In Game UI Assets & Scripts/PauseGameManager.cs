using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    public GameObject pauseCanvas; // Drag your Pause Canvas here
    public GameObject settingsCanvas; // Drag your Settings Canvas here
    public GameObject mainMenuCanvas; // Drag your Main Menu Canvas here
    public PlayerMovement playerController; // Reference to your Player Controller script
    public CharacterController charController;
    public MonoBehaviour cameraMovementScript; // Reference to your camera movement script

    public UnityEngine.UI.Button continueButton; // Drag your Continue Button here in the Inspector 

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu and other overlays are hidden at the start
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Assign the Continue button's click event to the ContinueGame function
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(ContinueGame);
        }
    }

    void Update()
    {
        // Toggle pause when "P" is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Resume when pressing P again
            }
            else
            {
                PauseGame(); // Pause when pressing P
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; // Freeze the game
        if (playerController != null)
        {
            playerController.enabled = false; // Disable player movement
        }

        if (charController != null)
        {
            charController.enabled = false; // Disable player movement
        }
        
        // Disable camera movement
        if (cameraMovementScript != null)
        {
            cameraMovementScript.enabled = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; // Resume the game
        if (playerController != null)
        {
            playerController.enabled = true; // Enable player movement
        }

        if (charController != null)
        {
            charController.enabled = true; // enable player movement
        }

                // reenable camera movement
        if (cameraMovementScript != null)
        {
            cameraMovementScript.enabled = true;
        }
    }

    public void ContinueGame()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; // Resume the game
        if (playerController != null)
        {
            playerController.enabled = true; // Enable player movement
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void OpenSettings()
    {
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
