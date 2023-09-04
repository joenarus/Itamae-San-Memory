using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient Card", menuName = "Ingredient Card")]
public class IngredientCard : ScriptableObject
{
    public new string name;

    public Sprite sprite;
}
