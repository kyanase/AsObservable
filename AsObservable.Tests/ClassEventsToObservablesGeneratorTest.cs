using System;
using NUnit.Framework;

namespace AsObservable.Tests
{
    internal class ClassEventsToObservablesGeneratorTest
    {
        [Test]
        public void ClassEvents()
        {
            var generate = TypeToObservablesGenerator.Generate(typeof(ClassEventsToObservablesGeneratorSampleClass));
            Console.WriteLine(generate);
            var expected = @"public static class ClassEventsToObservablesGeneratorSampleClassObservableExtensions
{
    public static IObservable<EventPattern<EventArgs>> SampleEventAsObservable(this ClassEventsToObservablesGeneratorSampleClass @this)
    {
        return Observable.FromEventPattern<EventHandler, EventArgs>(
            h => @this.SampleEvent += h, 
            h => @this.SampleEvent -= h);
    }
    public static IObservable<EventPattern<int>> SampleGenericEventAsObservable(this ClassEventsToObservablesGeneratorSampleClass @this)
    {
        return Observable.FromEventPattern<EventHandler<int>, int>(
            h => @this.SampleGenericEvent += h, 
            h => @this.SampleGenericEvent -= h);
    }
    public static IObservable<EventPattern<List<int>>> SampleGenericGenericEventAsObservable(this ClassEventsToObservablesGeneratorSampleClass @this)
    {
        return Observable.FromEventPattern<EventHandler<List<int>>, List<int>>(
            h => @this.SampleGenericGenericEvent += h, 
            h => @this.SampleGenericGenericEvent -= h);
    }
    public static IObservable<EventPattern<EventArgs>> StaticEventAsObservable()
    {
        return Observable.FromEventPattern<EventHandler, EventArgs>(
            h => ClassEventsToObservablesGeneratorSampleClass.StaticEvent += h, 
            h => ClassEventsToObservablesGeneratorSampleClass.StaticEvent -= h);
    }
}";
            Assert.AreEqual(expected, generate);
        }

#pragma warning restore 67
    }
}