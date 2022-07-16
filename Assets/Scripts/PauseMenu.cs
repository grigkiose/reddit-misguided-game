using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    [SerializeField] private GameObject FpsCamera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !OpenCloseInventory.inventoryOpen){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused=false;
        FpsCamera.GetComponent<FirstPersonLook>().sensitivity=2;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause(){
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused=true;
        FpsCamera.GetComponent<FirstPersonLook>().sensitivity=0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    
    public void LoadMenu(){
        Time.timeScale = 1f;
        GameIsPaused=false;
        FpsCamera.GetComponent<FirstPersonLook>().sensitivity=2;
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
