using System;
using NUnit.Framework;

namespace AsObservable.Tests
{
    public class TypeCollectionToObservableGeneratorTest
    {
        [Test]
        public void Generate()
        {
            var types = new[] {typeof(TypeCollectionToObservableGeneratorSampleClass)};
            var actual = TypeCollectionToObservableGenerator.Generate(types);
            Console.WriteLine(actual);
            var expected =
                @"namespace Observables.AsObservable.Tests
{
    public static class TypeCollectionToObservableGeneratorSampleClassObservableExtensions
    {
        public static IObservable<EventPattern<EventArgs>> SampleEventAsObservable(this TypeCollectionToObservableGeneratorSampleClass @this)
        {
            return Observable.FromEventPattern<EventHandler, EventArgs>(
                h => @this.SampleEvent += h, 
                h => @this.SampleEvent -= h);
        }
    }          
}";


            Assert.AreEqual(expected, actual);
        }

#pragma warning restore 67

        [Test]
        public void GenerateForEmptyArray()
        {
            var actual = TypeCollectionToObservableGenerator.Generate(new Type[0]);
            Assert.AreEqual("", actual);
        }

        [Test]
        public void GenerateFromNoEventTypes()
        {
            var actual = TypeCollectionToObservableGenerator.Generate(new[] {typeof(SampleWithoutEventClass)});
            Assert.AreEqual("", actual);
        }

        private class SampleWithoutEventClass
        {
        }
    }
}