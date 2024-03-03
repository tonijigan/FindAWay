using UnityEngine;
using Agava.YandexGames;

public class Localisation : MonoBehaviour
{
    private const string LanguageTr = "tr";
    private const string LanguageRu = "ru";
    private const string LanguageEn = "en";

    public string ChangeLanguage(string trLanguage, string ruLanguage, string enLanguage)
    {
        var currentLanguage = YandexGamesSdk.Environment.i18n.lang;
        var currentAnonymousName = currentLanguage switch
        {
            LanguageTr => trLanguage,
            LanguageRu => ruLanguage,
            LanguageEn => enLanguage,
            _ => ""
        };

        return currentAnonymousName;
    }
}