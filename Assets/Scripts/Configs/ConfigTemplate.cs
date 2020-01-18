﻿using System.Collections.Generic;
using UnityEngine;

namespace Client.Configs
{
    public abstract class ConfigTemplate<TKey, TValue, TItem> : ScriptableObject, ISerializationCallbackReceiver 
        where TItem : IConfigItem<TKey, TValue>
    {
#pragma warning disable 649
        [SerializeField]
        private TItem[] _items;

        private Dictionary<TKey, TValue> _itemsDictionary;
#pragma warning restore 649

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            _itemsDictionary = new Dictionary<TKey, TValue>(_items.Length);
            foreach (var viewConfigItem in _items)
            {
                var key = viewConfigItem.GetKey();
                if (_itemsDictionary.ContainsKey(key))
                {
                    Debug.LogError($"Value with key {key} has been already added into dictionary");
                    continue;
                }
                _itemsDictionary.Add(key, viewConfigItem.GetValue());
            }
        }

        public bool GetValue(TKey key, out TValue value)
        {
            return _itemsDictionary.TryGetValue(key, out value);
        }
    }
}