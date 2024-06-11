using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "ScriptableObjects/Currency/SimpleCurrency", order = 1)]
public class CurrencyData : ScriptableObject
{
    [SerializeField] protected string currencyName;
    [SerializeField] protected int currencyAmount;
    [SerializeField] protected Sprite currencyLogo;

    public int CurrencyAmount => currencyAmount;
    public Sprite CurrencyLogo => currencyLogo;
    public string CurrencyText => currencyAmount.ToString("0000");

    public void UpdateCurrency(int amountGained)
    {
        currencyAmount += amountGained;
    }

    public bool CanUseCurrency(int amountNeeded)
    {
        return currencyAmount >= amountNeeded;
    }

    public bool UseCurrency(int amountPayment)
    {
        currencyAmount -= amountPayment;
        
        return true;
    }
}

public enum Currency {Diamanod, Gold, Silver, Coins, Cash}