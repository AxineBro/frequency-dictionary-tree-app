using FrequencyDictionaryApp.Core.Interfaces;
using FrequencyDictionaryApp.Core.Models;
using FrequencyDictionaryApp.Core.Services;
using FrequencyDictionaryApp.Infrastructure.Implementations;

namespace FrequencyDictionaryApp.Infrastructure.Factories;

/// <summary>
/// Фабрика для создания реализаций частотного словаря.
/// </summary>
public static class FrequencyDictionaryFactory
{
    /// <summary>
    /// Создаёт словарь на основе бинарного дерева поиска.
    /// </summary>
    public static IFrequencyDictionary CreateTreeBased()
    {
        var tree = new BinarySearchTreeMap<string, int>();
        var processor = new TextProcessor();
        return new TreeBasedFrequencyDictionary(tree, processor);
    }
}