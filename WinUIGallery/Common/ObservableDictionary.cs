using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation.Collections;

namespace WinUIGallery.Common
{
	/// <summary>
	/// Implementation of IObservableMap that supports reentrancy for use as a default view
	/// model.
	/// </summary>
	public class ObservableDictionary : IObservableMap<string, object>
	{
		class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
		{
			public ObservableDictionaryChangedEventArgs(CollectionChange change, string key)
			{
				CollectionChange = change;
				Key = key;
			}

			public CollectionChange CollectionChange { get; private set; }
			public string Key { get; private set; }
		}

		Dictionary<string, object> _dictionary = new Dictionary<string, object>();
		public event MapChangedEventHandler<string, object> MapChanged;

		void InvokeMapChanged(CollectionChange change, string key)
		{
			MapChanged?.Invoke(this, new ObservableDictionaryChangedEventArgs(change, key));
		}

		public void Add(string key, object value)
		{
			_dictionary.Add(key, value);
			InvokeMapChanged(CollectionChange.ItemInserted, key);
		}

		public void Add(KeyValuePair<string, object> item) => Add(item.Key, item.Value);

		public bool Remove(string key)
		{
			if (_dictionary.Remove(key))
			{
				InvokeMapChanged(CollectionChange.ItemRemoved, key);
				return true;
			}

			return false;
		}

		public bool Remove(KeyValuePair<string, object> item)
		{
			if (_dictionary.TryGetValue(item.Key, out object currentValue) &&
				object.Equals(item.Value, currentValue) && _dictionary.Remove(item.Key))
			{
				InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
				return true;
			}

			return false;
		}

		public object this[string key]
		{
			get
			{
				return _dictionary[key];
			}
			set
			{
				_dictionary[key] = value;
				InvokeMapChanged(CollectionChange.ItemChanged, key);
			}
		}

		public void Clear()
		{
			var priorKeys = _dictionary.Keys.ToArray();
			_dictionary.Clear();

			foreach (var key in priorKeys)
				InvokeMapChanged(CollectionChange.ItemRemoved, key);
		}

		public ICollection<string> Keys => _dictionary.Keys;

		public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

		public bool TryGetValue(string key, out object value)
		{
			return _dictionary.TryGetValue(key, out value);
		}

		public ICollection<object> Values => _dictionary.Values;

		public bool Contains(KeyValuePair<string, object> item) => _dictionary.Contains(item);

		public int Count => _dictionary.Count;

		public bool IsReadOnly => false;

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			int arraySize = array.Length;

			foreach (var pair in _dictionary)
			{
				if (arrayIndex >= arraySize) break;
				array[arrayIndex++] = pair;
			}
		}
	}
}