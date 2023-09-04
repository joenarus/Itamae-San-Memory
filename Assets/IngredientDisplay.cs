using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientDisplay : MonoBehaviour
{
    public IngredientCard card;

    public TextMeshProUGUI nameText;

    public Image mainSprite;

    public bool isFaceDown = true;

    public GameObject front;
    public GameObject back;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        mainSprite.sprite = card.sprite;
        if (isFaceDown)
        {
            front.SetActive(false);
            back.SetActive(true);
        }
    }

    public void FlipCard()
    {
        isFaceDown = !isFaceDown;
        front.SetActive(!isFaceDown);
        back.SetActive(isFaceDown);
    }
}
