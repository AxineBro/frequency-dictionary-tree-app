using System;
using System.Collections.Generic;
using FrequencyDictionaryApp.Core.Interfaces;

namespace FrequencyDictionaryApp.Core.Models;

/// <summary>
/// Реализация бинарного дерева поиска (BST) с поддержкой ключей и значений.
/// Не рекурсивный InOrderTraversal (защита от stack overflow).
/// </summary>
public class BinarySearchTreeMap<TKey, TValue> : IBinarySearchTreeMap<TKey, TValue>
    where TKey : IComparable<TKey>
{
    private class Node
    {
        public TKey Key { get; }
        public TValue Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    private Node? _root;
    private int _count;

    /// <inheritdoc />
    public int Count => _count;

    /// <inheritdoc />
    public void Clear()
    {
        _root = null;
        _count = 0;
    }

    /// <inheritdoc />
    public bool Contains(TKey key) => FindNode(key) != null;

    /// <inheritdoc />
    public TValue GetValueOrDefault(TKey key, TValue defaultValue = default)
    {
        var node = FindNode(key);
        return node != null ? node.Value : defaultValue;
    }

    /// <inheritdoc />
    public IEnumerable<(TKey Key, TValue Value)> InOrderTraversal()
    {
        if (_root == null) yield break;

        var stack = new Stack<Node>();
        var current = _root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            yield return (current.Key, current.Value);
            current = current.Right;
        }
    }

    /// <inheritdoc />
    public void Insert(TKey key, TValue value) => _root = InsertRecursive(_root, key, value);

    /// <inheritdoc />
    public void Upsert(TKey key, TValue initialValue, Func<TValue, TValue> updateFunc)
    {
        ArgumentNullException.ThrowIfNull(updateFunc);

        var node = FindNode(key);
        if (node != null)
            node.Value = updateFunc(node.Value);
        else
            Insert(key, initialValue);
    }

    private Node? FindNode(TKey key)
    {
        var current = _root;
        while (current != null)
        {
            int comparison = key.CompareTo(current.Key);
            if (comparison == 0) return current;
            current = comparison < 0 ? current.Left : current.Right;
        }
        return null;
    }

    private Node InsertRecursive(Node? node, TKey key, TValue value)
    {
        if (node == null)
        {
            _count++;
            return new Node(key, value);
        }

        int comparison = key.CompareTo(node.Key);
        if (comparison < 0)
            node.Left = InsertRecursive(node.Left, key, value);
        else if (comparison > 0)
            node.Right = InsertRecursive(node.Right, key, value);
        else
            node.Value = value;

        return node;
    }
}