using System;
using JetBrains.Annotations;

namespace AsObservable.Tests
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
#pragma warning disable 67
    internal class SampleClass
    {
        public event EventHandler SampleEvent;
    }
}