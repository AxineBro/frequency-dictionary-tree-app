using System;
using System.Collections.Generic;
using Snowball;

namespace FrequencyDictionaryApp.Core.Services;

/// <summary>
/// Отвечает за токенизацию текста, очистку и стемминг русских слов.
/// </summary>
public sealed class TextProcessor
{
    private readonly Stemmer _stemmer = new RussianStemmer();

    /// <summary>
    /// Разделители текста (пробелы, табы, переносы строк и неразрывный пробел).
    /// </summary>
    private static readonly char[] Separators = [' ', '\t', '\r', '\n', '\u00A0'];

    /// <summary>
    /// Разбивает текст на "сырые" токены (без стемминга).
    /// </summary>
    public IEnumerable<string> ExtractWordsRaw(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            yield break;

        foreach (var token in text.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
        {
            yield return token;
        }
    }

    /// <summary>
    /// Очищает слово от пунктуации по краям и приводит к нижнему регистру.
    /// </summary>
    public string Normalize(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return string.Empty;

        var cleaned = word;

        while (cleaned.Length > 0 && char.IsPunctuation(cleaned[0]))
            cleaned = cleaned.Substring(1);

        while (cleaned.Length > 0 && char.IsPunctuation(cleaned[^1]))
            cleaned = cleaned.Substring(0, cleaned.Length - 1);

        return cleaned.ToLowerInvariant().Trim();
    }

    /// <summary>
    /// Применяет Snowball-стемминг.
    /// </summary>
    public string Stem(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return string.Empty;

        return _stemmer.Stem(word) ?? string.Empty;
    }

    /// <summary>
    /// Старый метод: сразу возвращает стемы (оставлен для совместимости).
    /// </summary>
    public IEnumerable<string> ExtractAndNormalizeWords(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            yield break;

        foreach (var token in ExtractWordsRaw(text))
        {
            var normalized = Normalize(token);

            if (string.IsNullOrWhiteSpace(normalized))
                continue;

            var stemmed = Stem(normalized);

            if (!string.IsNullOrEmpty(stemmed))
                yield return stemmed;
        }
    }
}