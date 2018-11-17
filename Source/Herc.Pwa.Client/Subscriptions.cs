namespace Herc.Pwa.Client
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.Design;
  using BlazorState;

  public class Subscriptions
  {
    public Subscriptions()
    {
      BlazorStateComponentReferencesDictionary = new Dictionary<Type, List<WeakReference<BlazorStateComponent>>>();
    }

    private Dictionary<Type, List<WeakReference<BlazorStateComponent>>> BlazorStateComponentReferencesDictionary;

    public Subscriptions Add(Type aStateType, BlazorStateComponent aBlazorStateComponent)
    {

      if (!typeof(IState).IsAssignableFrom(aStateType))
      {
        throw new ArgumentException("Type must implement IState");
      }

      if (!(BlazorStateComponentReferencesDictionary.TryGetValue(aStateType, out List<WeakReference<BlazorStateComponent>> blazorStateComponentReferences)))
      {
        blazorStateComponentReferences = new List<WeakReference<BlazorStateComponent>>();
        BlazorStateComponentReferencesDictionary.Add(aStateType, blazorStateComponentReferences);
      }

      blazorStateComponentReferences.Add(new WeakReference<BlazorStateComponent>(aBlazorStateComponent));

      return this;
    }

    public void ReRenderSubscribers<T>() where T : IState
    {
      Type aStateType = typeof(T);

      ReRenderSubscribers(aStateType);
    }
    /// <summary>
    /// Will iterate over all subscriptions for the given type and call ReRender on each.
    /// If the target component no longer exists it will remove its subscription.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ReRenderSubscribers(Type aStateType)
    {
      if ((BlazorStateComponentReferencesDictionary.TryGetValue(aStateType, out List<WeakReference<BlazorStateComponent>> blazorStateblazorStateComponentReferencesComponents)))
      {
        WeakReference<BlazorStateComponent>[] blazorStateComponentReferencesArray = blazorStateblazorStateComponentReferencesComponents.ToArray();

        foreach (WeakReference<BlazorStateComponent> aBlazorStateComponentReference in blazorStateComponentReferencesArray)
        {
          if (aBlazorStateComponentReference.TryGetTarget(out BlazorStateComponent target))
          {
            Console.WriteLine($"ReRender: {target.GetType().Name}");
            target.ReRender();
          }
          else
          {
            blazorStateblazorStateComponentReferencesComponents.Remove(aBlazorStateComponentReference);
          }
        }
      }
    }
  }
}
