namespace System.Collections.Generic
{
  public static class DictionaryExtentions
  {


    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> aDicttionary, TKey aKey)
        where TValue : new()
    {

      if (!aDicttionary.TryGetValue(aKey, out TValue value))
      {
        value = new TValue();
        aDicttionary.Add(aKey, value);
      }

      return value;
    }
  }
}
