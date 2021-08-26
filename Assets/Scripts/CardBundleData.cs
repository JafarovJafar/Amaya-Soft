using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 10)]
public class CardBundleData : ScriptableObject
{
    public string ID => _id;
    [SerializeField] string _id;
    
    public enum Difficulties
    {
        Easy,
        Normal,
        Hard,
    }

    [SerializeField] Difficulties _difficulty;
    public Difficulties Difficulty => _difficulty;
    
    [SerializeField] CardData[] _cardData;
    public CardData[] CardData => _cardData;

    public int CorrectItemIndex => correctItemIndex;
    [SerializeField] int correctItemIndex;
}