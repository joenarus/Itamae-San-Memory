using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RecipeDisplay : MonoBehaviour
{
    public RecipeCard card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Image mainSprite;

    public bool isFaceDown = true;

    public GameObject front;
    public GameObject back;

    public GameObject ingredientIconPrefab;
    public GameObject ingredientList;

    private int ingredientImageSize = 36;
    private int ingredientImagePadding = 12;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        mainSprite.sprite = card.sprite;
        priceText.text = "$" + card.price;
        bool isEvenNumberOfIngredients = card.ingredients.Length % 2 == 0;
        int startingX = 0 - ((ingredientImageSize + ingredientImagePadding) * (card.ingredients.Length / 2));
        startingX += isEvenNumberOfIngredients ? (ingredientImagePadding / 2) + (ingredientImageSize / 2) : 0;
        
        for (int i = 0; i < card.ingredients.Length; i ++)
        {
            float x = startingX + (i * (ingredientImageSize + ingredientImagePadding));
           
            GameObject currentObj = Instantiate(ingredientIconPrefab, ingredientList.transform);
            currentObj.transform.localPosition = new Vector3(x, 0, 0);
            currentObj.GetComponent<Image>().sprite = card.ingredients[i].sprite;
        }

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
