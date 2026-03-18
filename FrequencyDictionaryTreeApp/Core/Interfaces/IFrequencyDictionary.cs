using System.Collections.Generic;
using FrequencyDictionaryApp.Core.Enums;

namespace FrequencyDictionaryApp.Core.Interfaces;

/// <summary>
/// Основной интерфейс частотного словаря.
/// </summary>
public interface IFrequencyDictionary
{
    /// <summary>
    /// Строит словарь из переданного текста.
    /// </summary>
    void BuildFrom(string text);

    /// <summary>
    /// Возвращает отформатированные строки для вывода.
    /// </summary>
    IReadOnlyList<string> GetFormattedLines(SortMode mode);

    /// <summary>
    /// Очищает словарь.
    /// </summary>
    void Clear();

    /// <summary>
    /// Количество уникальных основ слов.
    /// </summary>
    int UniqueWordCount { get; }
}