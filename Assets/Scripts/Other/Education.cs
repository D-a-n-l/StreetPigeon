using UnityEngine;
using UnityEngine.UI;

public class Education : MonoBehaviour
{
    [SerializeField] private Sprite[] imageHelp;
    [SerializeField] private Image image;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject startGameButton;

    private int page = 0;

    private void Start()
    {
        image.sprite = imageHelp[page];
        backButton.SetActive(false);
    }

    public void NextSpriteHelp()
    {
        if (page < imageHelp.Length - 1)
        {
            page += 1;
            image.sprite = imageHelp[page];
            backButton.SetActive(true);
        }
        
        if (page == imageHelp.Length - 1)
        {
            nextButton.SetActive(false);
            startGameButton.SetActive(true);
        }

    }

    public void BackSpriteHelp()
    {
        if (page != 0)
        {
            page -= 1;
            image.sprite = imageHelp[page];
            nextButton.SetActive(true);
        }

        if (page == 0)
        {
            backButton.SetActive(false);
        }
    }
}
