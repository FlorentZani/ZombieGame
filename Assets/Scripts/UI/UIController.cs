using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField]
    List<Image> guns = null;

    [SerializeField]
    List<Image> gunOutlines = null;

    [SerializeField]
    GameObject gunMenu = null;

    bool isMenuOpen = false;
    bool canMoveMenu = true;

    public Action MenuOpen;
    public Action MenuClosed;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Z) && canMoveMenu)
        {
            HandleWeaponChangedUI(0);
            StartCoroutine(MoveMenu(false));
        }
        else if (Input.GetKey(KeyCode.X) && canMoveMenu)
        {
            HandleWeaponChangedUI(1);
            StartCoroutine(MoveMenu(false));
        }
        else if (Input.GetKey(KeyCode.C) && canMoveMenu)
        {
            HandleWeaponChangedUI(2);
            StartCoroutine(MoveMenu(false));
        }
        else if (Input.GetKey(KeyCode.V) && canMoveMenu)
        {
            HandleWeaponChangedUI(3);
            StartCoroutine(MoveMenu(false));
        }
    }

    IEnumerator MoveMenu(bool isOpen)
    {
        float finalXPosition = isMenuOpen ? -300f : 0f;
        canMoveMenu = false;

        while (gunMenu.transform.position.x != finalXPosition)
        {
            if (isOpen)
            {
                //close menu
                gunMenu.transform.position = new Vector3(gunMenu.transform.position.x - 50, gunMenu.transform.position.y, gunMenu.transform.position.z);
            }
            else
            {
                //open menu
                gunMenu.transform.position = new Vector3(gunMenu.transform.position.x + 50, gunMenu.transform.position.y, gunMenu.transform.position.z);
            }

            yield return new WaitForSeconds(0.05f);
        }

        isMenuOpen = !isMenuOpen;
        if (!isMenuOpen)
        {
            MenuClosed?.Invoke();
            canMoveMenu = true;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(MoveMenu(true));
            MenuOpen?.Invoke();
        }
    }

    void HandleWeaponChangedUI(int i)
    {
        for (int j = 0; j < guns.Count; j++)
        {
            if (j == i)
            {
                gunOutlines[j].enabled = true;
                gunOutlines[j].rectTransform.localScale = new Vector3(2f, 2f, 0f);
            }
            else
            {
                gunOutlines[j].enabled = false;
                gunOutlines[j].rectTransform.localScale = new Vector3(1f, 1f, 0f);
            }
        }
    }
}
