using System;
using System.Collections.Generic;
using System.Linq;
using FrequencyDictionaryApp.Core.Enums;
using FrequencyDictionaryApp.Core.Interfaces;
using FrequencyDictionaryApp.Core.Models;
using FrequencyDictionaryApp.Core.Services;

namespace FrequencyDictionaryApp.Infrastructure.Implementations;

/// <summary>
/// Реализация частотного словаря на основе BinarySearchTreeMap.
/// Использует TextProcessor для нормализации и стемминга.
/// </summary>
public sealed class TreeBasedFrequencyDictionary : IFrequencyDictionary
{
    private readonly IBinarySearchTreeMap<string, int> _tree;
    private readonly TextProcessor _textProcessor;
    private readonly Dictionary<string, Dictionary<string, int>> _stemToForms = new();

    public TreeBasedFrequencyDictionary(
        IBinarySearchTreeMap<string, int> tree,
        TextProcessor textProcessor)
    {
        _tree = tree ?? throw new ArgumentNullException(nameof(tree));
        _textProcessor = textProcessor ?? throw new ArgumentNullException(nameof(textProcessor));
    }

    /// <inheritdoc />
    public int UniqueWordCount => _tree.Count;

    /// <inheritdoc />
    public void BuildFrom(string text)
    {
        _tree.Clear();
        _stemToForms.Clear();

        foreach (var word in _textProcessor.ExtractWordsRaw(text))
        {
            var normalized = _textProcessor.Normalize(word);
            if (string.IsNullOrWhiteSpace(normalized))
                continue;

            var stem = _textProcessor.Stem(normalized);

            _tree.Upsert(stem, 1, count => count + 1);

            if (!_stemToForms.TryGetValue(stem, out var forms))
            {
                forms = new Dictionary<string, int>();
                _stemToForms[stem] = forms;
            }

            forms[normalized] = forms.GetValueOrDefault(normalized, 0) + 1;
        }
    }

    /// <inheritdoc />
    public IReadOnlyList<string> GetFormattedLines(SortMode mode)
    {
        var entries = _tree.InOrderTraversal().ToList();

        if (mode == SortMode.FrequencyDescending)
        {
            entries.Sort((a, b) =>
            {
                int countCompare = b.Value.CompareTo(a.Value);
                return countCompare != 0
                    ? countCompare
                    : string.CompareOrdinal(a.Key, b.Key);
            });
        }

        return entries
            .Select(x =>
            {
                var representative = GetRepresentative(x.Key);
                return $"{x.Value}: {representative}";
            })
            .ToList()
            .AsReadOnly();
    }

    /// <inheritdoc />
    public void Clear()
    {
        _tree.Clear();
        _stemToForms.Clear();
    }

    /// <summary>
    /// Выбирает наиболее "красивую" форму слова:
    /// 1. Самая частая
    /// 2. При равенстве — самая длинная
    /// </summary>
    private string GetRepresentative(string stem)
    {
        if (!_stemToForms.TryGetValue(stem, out var forms) || forms.Count == 0)
            return stem;

        return forms
            .OrderByDescending(kv => kv.Value)
            .ThenByDescending(kv => kv.Key.Length)
            .First()
            .Key;
    }
}