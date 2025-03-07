using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorHacking : MonoBehaviour
{
    public PlayerCamera playerCamera;
    public PlayerCamera camera2;
    public Player player;
    public Canvas miniGameCanva;
    Coroutine WinCoroutine = null;
    public GameObject winTxt;
    public GameObject loseTxt;
    public GameObject buttonContainer;
    List<Button> buttons = new List<Button>();
    List<Button> suiteButtons = new List<Button>();
    List<Button> pressedButtons = new List<Button>();

    void Start()
    {
        miniGameCanva.gameObject.SetActive(false);
        winTxt.SetActive(false);
        loseTxt.SetActive(false);
    }

    public void MiniGame()
    {
        playerCamera.enabled = false;
        camera2.enabled = false;
        miniGameCanva.gameObject.SetActive(true);

        //Choisis 4 boutons, les allumes un par un
        //Le joueur doit réécrire la séquence en appuyant sur les boutons ou sur les touches du clavier correspondante
        //victoire ou défaite bim

        for(int i = 0; i < buttonContainer.transform.childCount; i++)
        {
            buttons.Add(buttonContainer.transform.GetChild(i).GetComponent<Button>());
        }

        while(suiteButtons.Count <= 3)
        {
            int randomButton = Random.Range(0, buttons.Count);
            suiteButtons.Add(buttons[randomButton]);
        }

        StartCoroutine(ShowLine());
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator ShowLine()
    {
        for(int i = 0; i < suiteButtons.Count; i++)
        {
            ColorBlock colorBlock = suiteButtons[i].colors;
            colorBlock.normalColor = Color.red;
            suiteButtons[i].colors = colorBlock;

            yield return new WaitForSeconds(1);

            colorBlock.normalColor = Color.white;
            suiteButtons[i].colors = colorBlock;
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddingButton(Button button)
    {
        pressedButtons.Add(button);
    }

    void Update()
    {
        if(pressedButtons.Count == suiteButtons.Count)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            for(int i = 0; i < pressedButtons.Count; i++)
            {
               if(pressedButtons[i] == suiteButtons[i])
               {
                    player.gameFinished = true; 
                    if(WinCoroutine == null)
                    {
                        WinCoroutine = StartCoroutine(Winning());
                    }
               }
               else
               {
                StartCoroutine(Losing());
               }
            }
        }
    }

    IEnumerator Winning()
    {
        winTxt.SetActive(true);
        yield return new WaitForSeconds(2);
        winTxt.SetActive(false);

        while(transform.position.y < transform.position.y + 10)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
    }
    IEnumerator Losing()
    {
        loseTxt.SetActive(true);
        yield return new WaitForSeconds(2);
        loseTxt.SetActive(false);
    }
}
