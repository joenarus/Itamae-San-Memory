using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe Card", menuName = "Recipe Card")]
public class RecipeCard : ScriptableObject
{
    public new string name;

    public Sprite sprite;

    public int price;
    public IngredientCard[] ingredients;
}
