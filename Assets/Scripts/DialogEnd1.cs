using UnityEngine;
using TMPro;

public class DialogEnd1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Transform targetCharacter;
    public Vector3 offset = new Vector3(0, 2f, 0);
    public Camera mainCamera;
    
    private string[] sentences = new string[] 
    {
        //ends
        "Congrats, you have passed level One and cleared the harmful plastic in the ocean. ",
        "Plastic is very dangerous to marine life because it can take upwards of 500 years to decompose.",
        "When these plastics break down, they produce microplastics. These microplastics can be found in animals, and humans can also consume them!",



        
    };
    
    private int currentSentenceIndex = 0;
    
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
            
        ShowCurrentSentence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentence();
        }
        

        UpdateDialoguePanelPosition();
    }

    void UpdateDialoguePanelPosition()
    {
        if (targetCharacter != null && dialoguePanel != null)
        {

            Vector3 screenPos = mainCamera.WorldToScreenPoint(targetCharacter.position + offset);
            

            dialoguePanel.transform.position = screenPos;
        }
    }

    void ShowCurrentSentence()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = sentences[currentSentenceIndex];
    }

    void NextSentence()
    {
        currentSentenceIndex = (currentSentenceIndex + 1) % sentences.Length;
        ShowCurrentSentence();
    }
}