using System;
using UnityEngine;

[Serializable]
public class CardData
{
    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
    
    [SerializeField] string _identifier;
    [SerializeField] Sprite _sprite;
}