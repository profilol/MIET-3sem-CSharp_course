using System.Linq;

namespace Lab_04
{
    class TestCollections<TKey, TValue>
    {
        const int TIME_MEASURE_COUNT = 1000;
        private List<TKey> _keyCollection = new List<TKey>();
        private List<string> _stringCollection = new List<string>();

        private Dictionary<TKey, TValue> _keyDictionary = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> _stringDictionary = new Dictionary<string, TValue>();

        private GenerateElement<TKey, TValue> _elementGenerator;

        private int _generatedCount = 0;

        public TestCollections(int generatedCount, GenerateElement<TKey, TValue> elementGenerator) 
        {
            _elementGenerator = elementGenerator;
            _generatedCount = generatedCount;

            for (int i = 0; i < generatedCount; i++)
            {
                var curElement = _elementGenerator(i);

                _keyCollection.Add(curElement.Key);
                _stringCollection.Add(curElement.ToString());

                _keyDictionary.Add(curElement.Key, curElement.Value);
                _stringDictionary.Add(curElement.ToString(), curElement.Value);
            }
        }

        public void MeasureListKeyTime()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            long curTime = 0;
            var firstElement = _keyCollection[0];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyCollection.Contains(firstElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long firstElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var lastElement = _keyCollection[_generatedCount - 1];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyCollection.Contains(lastElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long lastElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var middleElement = _keyCollection[(_generatedCount - 1) / 2];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyCollection.Contains(middleElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long middleElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var missingElement = GenerateMissingElement().Key;
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyCollection.Contains(missingElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long missingElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            Console.WriteLine("\nMeasures for list key:");
            Console.WriteLine($"Elapsed ticks for first element = {firstElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for last element = {lastElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for midle element = {middleElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for missing element = {missingElementKeyListTicks}");
        }

        public void MeasureListStringTime()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            long curTime = 0;
            var firstElement = _stringCollection[0];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringCollection.Contains(firstElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long firstElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var lastElement = _stringCollection[_generatedCount - 1];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringCollection.Contains(lastElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long lastElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var middleElement = _stringCollection[(_generatedCount - 1) / 2];
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringCollection.Contains(middleElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long middleElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var missingElement = GenerateMissingElement().Key.ToString();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringCollection.Contains(missingElement);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long missingElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            Console.WriteLine("\nMeasures for list string:");
            Console.WriteLine($"Elapsed ticks for first element = {firstElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for last element = {lastElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for midle element = {middleElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for missing element = {missingElementKeyListTicks}");
        }

        public void MeasureDictionaryKeyTime()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            long curTime = 0;
            var firstElement = _keyDictionary.First();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyDictionary.ContainsKey(firstElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long firstElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var lastElement = _keyDictionary.Last();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyDictionary.ContainsKey(lastElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long lastElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var middleElement = _keyDictionary.ElementAt((_generatedCount - 1) / 2);
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyDictionary.ContainsKey(middleElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long middleElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var missingElement = GenerateMissingElement();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _keyDictionary.ContainsKey(missingElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long missingElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            Console.WriteLine("\nMeasures for dictionary key:");
            Console.WriteLine($"Elapsed ticks for first element = {firstElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for last element = {lastElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for midle element = {middleElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for missing element = {missingElementKeyListTicks}");
        }

        public void MeasureDictionaryStringTime()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            long curTime = 0;
            var firstElement = _stringDictionary.First();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsKey(firstElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long firstElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var lastElement = _stringDictionary.Last();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsKey(lastElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long lastElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var middleElement = _stringDictionary.ElementAt((_generatedCount - 1) / 2);
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsKey(middleElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long middleElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var missingElemnt = GenerateMissingElement();
            KeyValuePair<string, TValue> missingDictionaryElement = new KeyValuePair<string, TValue>(missingElemnt.Key.ToString(), missingElemnt.Value);
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsKey(missingDictionaryElement.Key);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long missingElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            Console.WriteLine("\nMeasures for dictionary string:");
            Console.WriteLine($"Elapsed ticks for first element = {firstElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for last element = {lastElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for midle element = {middleElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for missing element = {missingElementKeyListTicks}");
        }

        public void MeasureDictionaryStringValueTime()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            long curTime = 0;
            var firstElement = _stringDictionary.First();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsValue(firstElement.Value);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long firstElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var lastElement = _stringDictionary.Last();
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsValue(lastElement.Value);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long lastElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var middleElement = _stringDictionary.ElementAt((_generatedCount - 1) / 2);
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsValue(middleElement.Value);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long middleElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            curTime = 0;
            var missingElemnt = GenerateMissingElement();
            KeyValuePair<string, TValue> missingDictionaryElement = new KeyValuePair<string, TValue>(missingElemnt.Key.ToString(), missingElemnt.Value);
            for (int i = 0; i < TIME_MEASURE_COUNT; i++)
            {
                sw.Start();
                _stringDictionary.ContainsValue(missingDictionaryElement.Value);
                sw.Stop();
                curTime += sw.ElapsedTicks;
                sw.Restart();
            }
            long missingElementKeyListTicks = curTime / TIME_MEASURE_COUNT;

            Console.WriteLine("\nMeasures for dictionary by value string:");
            Console.WriteLine($"Elapsed ticks for first element = {firstElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for last element = {lastElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for midle element = {middleElementKeyListTicks}");
            Console.WriteLine($"Elapsed ticks for missing element = {missingElementKeyListTicks}");
        }

        private KeyValuePair<TKey, TValue> GenerateMissingElement()
        {
            return _elementGenerator(_generatedCount + 1);
        }

    }
}
