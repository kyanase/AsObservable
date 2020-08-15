# AsObservable
A library to generate extension methods which handle each event as an observable.

![](https://github.com/kyanase/AsObservable/workflows/.NET%20Core/badge.svg)

Original class
```csharp
        public class SampleClass
        {
            public event EventHandler SampleEvent;
        }
```

Code to generate
```csharp
            var types = new[] { typeof(SampleClass) };
            var code = TypeCollectionToObservableGenerator.Generate(types);
```

Generated code
```csharp
namespace Observables.ObservableGenerators.Tests
{
    public static class SampleClassObservableExtensions
    {
        public static IObservable<EventPattern<EventArgs>> SampleEventAsObservable(this SampleClass @this)
        {
            return Observable.FromEventPattern<EventHandler, EventArgs>(
                h => @this.SampleEvent += h, 
                h => @this.SampleEvent -= h);
        }
    }          
}
```

Usage
```csharp
var sampleClass = new SampleClass();
using (sampleClass.SampleEventAsObservable().Subscribe(pattern =>
{
    // Actions
}))
{
    
}
```
            
