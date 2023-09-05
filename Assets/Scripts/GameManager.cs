using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<IngredientCard> ingredientLibrary;
    public List<IngredientCard> ingredientDeck;
    public List<RecipeCard> recipeLibrary;
    public List<RecipeCard> recipeDeck;

    public GameObject IngredientBoard;
    public GameObject IngredientCardPrefab;

    public GameObject RecipeBoard;
    public GameObject RecipeCardPrefab;

    public int revealedRecipeCount;

    private Queue<RecipeCard> recipeQueue;
    

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
        { "Cucumber Roll", 2 },
        { "Spider Roll", 2 },
        { "Okimari", 2 },

    };
    // Start is called before the first frame update
    void Start()
    {
        CreateIngredientDeck();
        CreateRecipeDeck();
        ShuffleIngredientDeck();
        ShuffleRecipeDeck();
        Setup();
    }

    void CreateIngredientDeck ()
    {
        if (ingredientDeck.Count == 0)
        {
            ingredientDeck = new List<IngredientCard>();
            for (int i = 0; i < ingredientLibrary.Count; i++)
            {
                if (ingredientCardCatalog.ContainsKey(ingredientLibrary[i].name))
                {
                    ingredientDeck.AddRange(Enumerable.Repeat(0, ingredientCardCatalog[ingredientLibrary[i].name]).Select(x => ingredientLibrary[i]));
                }
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
                if(recipeCardCatalog.ContainsKey(recipeLibrary[i].name))
                {
                    recipeDeck.AddRange(Enumerable.Repeat(0, recipeCardCatalog[recipeLibrary[i].name]).Select(x => recipeLibrary[i]));
                }
            }
        }
    }

    
    // Sets up the ingredient board with prefabs
    void Setup()
    {
        for (int i = 0; i < ingredientDeck.Count; i++)
        {
            GameObject current = Instantiate(IngredientCardPrefab, IngredientBoard.transform);
            current.GetComponent<IngredientDisplay>().card = ingredientDeck[i];
        }
        for(int i = 0; i < revealedRecipeCount; i++)
        {
            DrawRecipeCard();
        }
    }

    public void ShuffleIngredientDeck()
    {
        for (int i = ingredientDeck.Count - 1; i > 0; --i)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            IngredientCard card = ingredientDeck[j];
            ingredientDeck[j] = ingredientDeck[i];
            ingredientDeck[i] = card;
        }
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

        recipeQueue = new Queue<RecipeCard>(recipeDeck);
    }

    public void DrawRecipeCard()
    {
        Debug.Log(recipeQueue);
        RecipeCard drawnCard = recipeQueue.Dequeue();
        GameObject obj = Instantiate(RecipeCardPrefab, RecipeBoard.transform);
        obj.GetComponent<RecipeDisplay>().card = drawnCard;
    }

    public void CompleteRecipe()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
}
