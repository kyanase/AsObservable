using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace AsObservable.Tests
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
#pragma warning disable 67
    internal class ClassEventsToObservablesGeneratorSampleClass
    {
        public event EventHandler SampleEvent;
        public event EventHandler<int> SampleGenericEvent;
        public event EventHandler<List<int>> SampleGenericGenericEvent;
        private event EventHandler PrivateEvent;
        public static event EventHandler StaticEvent;
    }
}