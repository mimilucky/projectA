using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestDialogue_Master : MonoBehaviour
{
    private Quest_Master questMaster;
    public GameObject TextBox;
    public Text talkText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    public bool isActive;



    void OnEnable()
    {
        SetInitialReferences();

    }
    void OnDisable()
    {

    }

    void SetInitialReferences()
    {       
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            DisableThis();
        }
        else
        {
            EnableThis();
        }
    }

    void ShowQuestDialogue(int qID)
    {

    }


    void Start()
    {

    }
     
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        talkText.text = textLines[currentLine];
       

        if (Input.GetKeyDown(KeyCode.Mouse0)&&! EventSystem.current.IsPointerOverGameObject())
        {
            currentLine += 1;

        }
        if (currentLine > endAtLine)
        {
            DisableThis();

        }
    }

    public void EnableThis()
    {
        TextBox.SetActive(true);
        isActive = true;
    }

    public void DisableThis()
    {
        TextBox.SetActive(false);
        isActive = false;     
    }

    public void ReloudScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
