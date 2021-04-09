using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string StartingMenu = "Main Menu";
    [SerializeField]
    private string RootMenu = "Main Menu";

    private MenuWidget ActiveWidget;

    private Dictionary<string, MenuWidget> Menus = new Dictionary<string, MenuWidget>();

    private void Start()
    {
        AppEvents.Invoke_OnMouseCursorEnable(true);
        DisableAllMenus();
        EnableMenu(StartingMenu);
    }

    public void AddMenu(string menuName, MenuWidget menuWidget)
    {
        if (string.IsNullOrEmpty(menuName))
        {
            return;
        }

        if (Menus.ContainsKey(menuName))
        {
            Debug.LogError("Menu already exists in dicitonary!");
            return;
        }

        if (menuWidget == null)
        {
            return;
        }

        Menus.Add(menuName, menuWidget);
    }

    public void EnableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
        {
            return;
        }

        if (Menus.ContainsKey(menuName))
        {
            DisableActiveMenu();

            ActiveWidget = Menus[menuName];
            ActiveWidget.EnableWidget();
        }
        else
        {
            Debug.LogError("Menu is not available in dictionary!");
        }

    }

    public void DisableMenu(string menuName)
    {
        if (string.IsNullOrEmpty(menuName))
        {
            return;
        }

        if (Menus.ContainsKey(menuName))
        {
            Menus[menuName].DisableWidget();
        }
        else
        {
            Debug.LogError("Menu is not available in dictionary!");
        }
    }

    public void ReturnToRootMenu()
    {
        EnableMenu(RootMenu);
    }

    private void DisableActiveMenu()
    {
        if (ActiveWidget)
        {
            ActiveWidget.DisableWidget();
        }
    }

    private void DisableAllMenus()
    {
        foreach (MenuWidget menu in Menus.Values)
        {
            menu.DisableWidget();
        }
    }
}
