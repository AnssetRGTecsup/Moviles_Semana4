using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/General/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private List<PremiumCurrency> premiumCurrencies;
    [SerializeField] private Currency[] premiumTags;
    [SerializeField] private List<NoPremiumCurrency> noPremiumCurrencies;
    [SerializeField] private Currency[] nonPremiumTags;

    public event Action onFinishLoad;

    private Hashtable premiumHash = new Hashtable();
    private Hashtable nonPremiumHash = new Hashtable();

    public void InitVariables()
    {
        for (int i = 0; i < premiumCurrencies.Count; i++)
        {
            premiumHash.Add(premiumTags[i], premiumCurrencies[i]);
        }

        for (int i = 0; i < noPremiumCurrencies.Count; i++)
        {
            nonPremiumHash.Add(nonPremiumTags[i], noPremiumCurrencies[i]);
        }

        onFinishLoad?.Invoke();
    }

    public bool ContainsPremiumKey(Currency currency)
    {
        return premiumHash.ContainsKey(currency);
    }

    public PremiumCurrency GetPremiumCurrency(Currency currency)
    {
        return (PremiumCurrency)premiumHash[currency];
    }

    public bool ContainsNonPremiumKey(Currency currency)
    {
        return nonPremiumHash.ContainsKey(currency);
    }

    public NoPremiumCurrency GetNonPremiumCurrency(Currency currency)
    {
        return (NoPremiumCurrency)nonPremiumHash[currency];
    }
}
