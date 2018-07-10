using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public enum MenuStates { Main, RSMenu, DSMenu, DSStart };
    public MenuStates currentstate;

    public GameObject mainMenu;
    public GameObject rsMenu;
    public GameObject dsMenu;
    public GameObject dsStart;

    private void Awake()
    {

        currentstate = MenuStates.Main;

    }

    private void Update()
    {
        
        switch (currentstate)
        {
            case MenuStates.Main:
                //gameobject active
                mainMenu.SetActive(true);
                rsMenu.SetActive(false);
                dsMenu.SetActive(false);
                dsStart.SetActive(false);
                break;

            case MenuStates.RSMenu:
                mainMenu.SetActive(false);
                rsMenu.SetActive(true);
                dsMenu.SetActive(false);
                dsStart.SetActive(false);
                break;

            case MenuStates.DSMenu:
                mainMenu.SetActive(false);
                rsMenu.SetActive(false);
                dsMenu.SetActive(true);
                dsStart.SetActive(false);
                break;

            case MenuStates.DSStart:
                mainMenu.SetActive(false);
                rsMenu.SetActive(false);
                dsMenu.SetActive(false);
                dsStart.SetActive(true);
                break;
        }

    }


    public void OnRSButton ()
    {
        Debug.Log("RSButton");
        currentstate = MenuStates.RSMenu;
    }

    public void OnDSButton ()
    {
        Debug.Log("DSButton");
        currentstate = MenuStates.DSMenu;
    }

    public void OnGOButton()
    {
        Debug.Log("GOButton");
        currentstate = MenuStates.DSStart;
    }

}
