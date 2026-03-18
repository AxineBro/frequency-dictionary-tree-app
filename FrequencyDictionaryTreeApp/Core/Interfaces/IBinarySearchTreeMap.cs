using System;
using System.Collections.Generic;

namespace FrequencyDictionaryApp.Core.Interfaces;

/// <summary>
/// Универсальное бинарное дерево поиска с поддержкой ключей и значений.
/// Позволяет хранить произвольные пары (key, value) и выполнять Upsert.
/// </summary>
/// <typeparam name="TKey">Тип ключа (должен реализовывать IComparable).</typeparam>
/// <typeparam name="TValue">Тип значения.</typeparam>
public interface IBinarySearchTreeMap<TKey, TValue>
    where TKey : IComparable<TKey>
{
    /// <summary>
    /// Возвращает количество уникальных элементов в дереве.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Очищает дерево полностью.
    /// </summary>
    void Clear();

    /// <summary>
    /// Проверяет наличие ключа в дереве.
    /// </summary>
    bool Contains(TKey key);

    /// <summary>
    /// Возвращает значение по ключу или default(TValue), если ключ не найден.
    /// </summary>
    TValue GetValueOrDefault(TKey key, TValue defaultValue = default);

    /// <summary>
    /// Возвращает все элементы в порядке InOrder (отсортировано по ключу).
    /// </summary>
    IEnumerable<(TKey Key, TValue Value)> InOrderTraversal();

    /// <summary>
    /// Вставляет новый элемент. Если ключ уже существует — заменяет значение.
    /// </summary>
    void Insert(TKey key, TValue value);

    /// <summary>
    /// Вставляет или обновляет значение через функцию.
    /// </summary>
    /// <param name="key">Ключ.</param>
    /// <param name="initialValue">Начальное значение при вставке.</param>
    /// <param name="updateFunc">Функция обновления существующего значения.</param>
    void Upsert(TKey key, TValue initialValue, Func<TValue, TValue> updateFunc);
}