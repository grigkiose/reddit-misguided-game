using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{

    public static bool inventoryOpen = false;
    public GameObject inventoryUi;
    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private GameObject pauseMenu;

    private bool openFromMenu = false;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.I) && !PauseMenu.GameIsPaused){
            if(inventoryOpen){
                CloseInventory();
            }else{
                OpenInventory();
            }   
        }  
        if(Input.GetKeyUp(KeyCode.Escape)&& inventoryOpen && openFromMenu){
            ReturnToMenu();
        } 
    }

    public void OpenInventory(){
        inventoryUi.SetActive(true);
        Time.timeScale = 0f;
        inventoryOpen=true;
        fpsCamera.GetComponent<FirstPersonLook>().sensitivity=0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void CloseInventory(){
        inventoryUi.SetActive(false);
        Time.timeScale = 1f;
        inventoryOpen=false;
        fpsCamera.GetComponent<FirstPersonLook>().sensitivity=2;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenFromMenu(){
        inventoryUi.SetActive(true);
        inventoryOpen=true;
        pauseMenu.SetActive(false);
        openFromMenu=true;
    }

    public void ReturnToMenu(){
        inventoryUi.SetActive(false);
        inventoryOpen=false;
        pauseMenu.SetActive(true);
        openFromMenu=false;
    }
}
