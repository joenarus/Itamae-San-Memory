using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<IngredientCard> ingredientLibrary;
    public List<IngredientCard> recipeLibrary;
    public List<IngredientCard> ingredientDeck;
    public List<RecipeCard> recipeDeck;

    // Handles how many of each ingredient are used in the game
    public Dictionary<string, int> ingredientCardCatalog = new Dictionary<string, int>()
    {
        { "Rice & Nori", 8 },
        { "Cucumber", 4 },
        { "Avocado", 4 },
        { "Salmon", 4 },
        { "Albacore", 3 },
        { "Fatty Tuna", 2 },
        { "Crab", 2 },
        { "Eel", 2 },
        { "Egg", 2 },
        { "Octopus", 1 },
        { "Tempura Shrimp", 1 },
        { "Daikon Sprouts", 1 },
        { "Flying Fish Roe", 1 },
        { "Salmon Roe", 1 },
        { "Sesame Seeds", 1 },
        { "Soy Sauce", 1 },
        { "Ginger", 1 },
        { "Wasabi", 1 },
    };


    // Handles how many of each recipe are used in the game
    public Dictionary<string, int> recipeCardCatalog = new Dictionary<string, int>()
    {
        { "Cucumber Roll", 20 },
    };
    // Start is called before the first frame update
    void Start()
    {
        CreateIngredientDeck();
        Setup();
        ShuffleRecipeDeck();
        createMarket();
    }

    void CreateIngredientDeck ()
    {
        if (ingredientDeck.Count == 0)
        {
            ingredientDeck = new List<IngredientCard>();
            for (int i = 0; i < ingredientLibrary.Count; i++)
            {
                ingredientDeck.AddRange(Enumerable.Repeat(0, ingredientCardCatalog[ingredientLibrary[i].name]).Select(x => ingredientLibrary[i]));
            }
        }
    }

    void CreateRecipeDeck()
    {
        if (recipeDeck.Count == 0)
        {
            recipeDeck = new List<RecipeCard>();
            for (int i = 0; i < recipeLibrary.Count; i++)
            {
                recipeDeck.AddRange(Enumerable.Repeat(0, recipeCardCatalog[recipeLibrary[i].name]).Select(x => recipeLibrary[i]));
            }
        }
    }

    void Setup()
    {
        
    }

    public void ShuffleRecipeDeck()
    {
        for (int i = recipeDeck.Count - 1; i > 0; --i)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            RecipeCard card = recipeDeck[j];
            recipeDeck[j] = recipeDeck[i];
            recipeDeck[i] = card;
        }
    }

    public void createMarket()
    {
        //Market setup
        //for (int i = 0; i < players.Count * 3; i++)
        //{
        //    GameObject selection = GameObject.Instantiate(selectionPrefab, new Vector3(market.position.x, market.transform.position.y - (i * 252), 0), Quaternion.identity, market); //instantiate market prefab
        //    selection.name = "Selection (" + i + ")"; // index names
        //    for (int j = 0; j < 9; j++)
        //    {
        //        Transform slot = selection.transform.Find("CardSlot (" + j + ")");
        //        IngredientCard card = deck[0];
        //        Debug.Log(card.name);
        //        GameObject cardToAdd = GameObject.Instantiate(cardPrefab, slot);
        //        cardToAdd.GetComponent<CardDisplay>().card = card;
        //        deck.RemoveAt(0);
        //    }
        //}
    }


    // Update is called once per frame
    void Update()
    {

    }
}
