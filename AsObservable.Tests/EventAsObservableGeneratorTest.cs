using System.Linq;
using NUnit.Framework;

namespace AsObservable.Tests
{
    public class EventAsObservableGeneratorTest
    {
        [Test]
        public void Generate()
        {
            var clickEvent = typeof(EventAsObservableGeneratorSampleClass).GetEvents().Single(e => e.Name == "Click");
            var code = EventAsObservableGenerator.GenerateExtensionMethodOfEvent(clickEvent);
            string expectedCode =
                @"public static IObservable<EventPattern<EventArgs>> ClickAsObservable(this EventAsObservableGeneratorSampleClass @this)
{
    return Observable.FromEventPattern<EventHandler, EventArgs>(
        h => @this.Click += h, 
        h => @this.Click -= h);
}";
            Assert.AreEqual(expectedCode, code);
        }

        [Test]
        public void GeneratePrimitive()
        {
            var clickEvent = typeof(EventAsObservableGeneratorSampleClass).GetEvents().Single(e => e.Name == "GenericPrimitiveEvent");
            var code = EventAsObservableGenerator.GenerateExtensionMethodOfEvent(clickEvent);
            string expectedCode =
                @"public static IObservable<EventPattern<int>> GenericPrimitiveEventAsObservable(this EventAsObservableGeneratorSampleClass @this)
{
    return Observable.FromEventPattern<EventHandler<int>, int>(
        h => @this.GenericPrimitiveEvent += h, 
        h => @this.GenericPrimitiveEvent -= h);
}";
            Assert.AreEqual(expectedCode, code);
        }

#pragma warning restore 67
    }
}