using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;        // Ana menüdeki butonları tutan GameObject
    public GameObject subMenu;         // Alt menüdeki butonları tutan GameObject
    public GameObject settingsMenu;    // Ayarlar menüsünü tutan GameObject
    public GameObject findGameMenu;    // Oyun bulma menüsünü tutan GameObject
    public GameObject createGameMenu;  // Oyun kurma menüsünü tutan GameObject
    public GameObject userProfileMenu; // Kullanıcı profili menüsünü tutan GameObject

    void Start()
    {
        // Başlangıçta ana menü açık, diğer menüler kapalı
        ShowMainMenu();
    }

    // Tüm menüleri kapatan yardımcı fonksiyon
    private void HideAllMenus()
    {
        mainMenu.SetActive(false);
        subMenu.SetActive(false);
        settingsMenu.SetActive(false);
        findGameMenu.SetActive(false);
        createGameMenu.SetActive(false);
        userProfileMenu.SetActive(false);
    }

    // Ana menüyü gösterir
    public void ShowMainMenu()
    {
        HideAllMenus();
        mainMenu.SetActive(true);
    }

    // Alt menüyü gösterir
    public void ShowSubMenu()
    {
        HideAllMenus();
        subMenu.SetActive(true);
    }

    // Ayarlar menüsünü gösterir
    public void ShowSettingsMenu()
    {
        HideAllMenus();
        settingsMenu.SetActive(true);
    }

    // Oyun bulma menüsünü gösterir
    public void ShowFindGameMenu()
    {
        HideAllMenus();
        findGameMenu.SetActive(true);
    }

    // Oyun kurma menüsünü gösterir
    public void ShowCreateGameMenu()
    {
        HideAllMenus();
        createGameMenu.SetActive(true);
    }

    // Kullanıcı profili menüsünü gösterir
    public void ShowUserProfile()
    {
        HideAllMenus();
        userProfileMenu.SetActive(true);
    }
}
