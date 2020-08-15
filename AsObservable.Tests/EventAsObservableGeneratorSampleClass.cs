using System;
using JetBrains.Annotations;

namespace AsObservable.Tests
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
#pragma warning disable 67
    internal class EventAsObservableGeneratorSampleClass
    {
        public event EventHandler Click;
        public event EventHandler<int> GenericPrimitiveEvent;
    }
}