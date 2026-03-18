namespace FrequencyDictionaryApp.Core.Enums;

/// <summary>
/// Режим сортировки частотного словаря.
/// </summary>
public enum SortMode
{
    /// <summary>
    /// Сортировка по алфавиту (используется InOrder дерева).
    /// </summary>
    Alphabetical,

    /// <summary>
    /// Сортировка по убыванию частоты (при равенстве — по алфавиту).
    /// </summary>
    FrequencyDescending
}