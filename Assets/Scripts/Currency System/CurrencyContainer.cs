using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyContainer : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private bool isPremium;
    [SerializeField] private Currency currencyType;

    [Header("UI Components")]
    [SerializeField] private Image logoImage;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Button addCurrency;
    [SerializeField] private Button addBigCurrency;
    [SerializeField] private Button payCurrency;

    private CurrencyData currencyData;

    private void OnEnable()
    {
        playerData.onFinishLoad += SetUpData;
    }

    private void OnDisable()
    {
        playerData.onFinishLoad -= SetUpData;
    }

    private void SetUpData()
    {
        if (isPremium)
        {
            if (playerData.ContainsPremiumKey(currencyType))
            {
                currencyData = playerData.GetPremiumCurrency(currencyType);
            }
            else
            {
                return;
            }
        }
        else
        {
            if (playerData.ContainsNonPremiumKey(currencyType))
            {
                currencyData = playerData.GetNonPremiumCurrency(currencyType);
            }
            else
            {
                return;
            }
        }

        logoImage.sprite = currencyData.CurrencyLogo;
        amountText.text = currencyData.CurrencyText;

        addCurrency.onClick.AddListener(() => AddCurrency(50));
        addBigCurrency.onClick.AddListener(() => AddCurrency(150));
        payCurrency.onClick.AddListener(() => UseCurrency(100));
    }

    private void AddCurrency(int amount)
    {
        currencyData.UpdateCurrency(amount);
        UpdateText();
    }

    private void UseCurrency(int payment)
    {
        if (currencyData.CanUseCurrency(payment))
        {
            currencyData.UseCurrency(payment);
            UpdateText();
        }
        else
        {
            Debug.LogWarning("Not enough Currency of type " + currencyType.ToString());
        }
        
    }

    private void UpdateText()
    {
        amountText.text = currencyData.CurrencyText;
    }
}
