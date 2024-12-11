using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu; // Ana menüdeki butonları tutan GameObject
    public GameObject subMenu; // Alt menüdeki butonları tutan GameObject

    void Start()
    {
        // Başlangıçta ana menü açık, alt menü kapalı
        ShowMainMenu();
    }

    // Ana menüyü gösterir ve alt menüyü gizler
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);  // Ana menü butonlarını aktif yap
        subMenu.SetActive(false); // Alt menü butonlarını gizle
    }

    // Alt menüyü gösterir ve ana menüyü gizler
    public void ShowSubMenu()
    {
        mainMenu.SetActive(false); // Ana menü butonlarını gizle
        subMenu.SetActive(true);  // Alt menü butonlarını aktif yap
    }
}
