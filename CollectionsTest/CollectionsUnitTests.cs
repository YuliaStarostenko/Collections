using Collections;
using System;

namespace CollectionsTest
{
    public class CollectionsUnitTests
    {
        private const int InitialCapacity = 16;

        [Test]
        public void Test_Collection_EmptyConstructor() 
        {
            var nums = new Collection<int>();

            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(100);

            Assert.That(nums[0], Is.EqualTo(100));

        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<string>("Hello", "Everyone", "Goodnight");

            Assert.That(nums.ToString(), Is.EqualTo("[Hello, Everyone, Goodnight]"));
        }

        [Test]
        public void Test_Collections_Add()
        {
            var nums = new Collection<double>();

            nums.Add(1.5);
            nums.Add(2);

            Assert.That(nums.ToString(), Is.EqualTo("[1,5, 2]"));
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;

           for (int i = 1; i < 18; i++)
            {
                nums.Add(i);
            }
            
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1, 3).ToArray();

            nums.AddRange(newNums);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3]"));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            var actualFirstNum = nums[0];

            Assert.AreEqual(1, actualFirstNum);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void Test_Collection_GetByInvalidIndex(int index)
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            Assert.That(() => nums[index], Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(10, 20).ToArray();

            nums.AddRange(newNums);

            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [TestCase(0, -8)]
        [TestCase(1, 9)]
        [TestCase(2, 7)]
        public void Test_Collection_InsertAt(int index, int number)
        {
            var nums = new Collection<int>(1, 3, 5);

            nums.InsertAt(index, number);

            Assert.AreEqual(number, nums[index]);    
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var nums = new Collection<int>();
            var newNums = Enumerable.Range(1, 16).ToArray();
            nums.AddRange(newNums);

            nums.InsertAt(16, 17);

            Assert.AreEqual(17, nums[16]);
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var nums = new Collection<int>(1, 3, 5);

            Assert.That(() => nums.InsertAt(-1, 89), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var nums = new Collection<int>(1, 3, 5);

            nums[0] = 10;

            Assert.AreEqual(10, nums[0]);
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var nums = new Collection<int>(1, 3, 5);

            Assert.That(() => nums[3] = 7, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            nums.Exchange(1, 2);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, nums[2]);
                Assert.AreEqual(5, nums[1]);
            });
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            nums.Exchange(0, 3);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(7, nums[0]);
                Assert.AreEqual(1, nums[3]);
            });
        }

        [Test]
        public void ExchangeInvalidIndexes()
        {
            var nums = new Collection<int>(1, 3, 5);

            Assert.That(() => nums.Exchange(-1, 89), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            nums.RemoveAt(0);

            Assert.AreEqual(3, nums[0]);
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            nums.RemoveAt(3);

            Assert.AreEqual(3, nums.Count);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void Test_Collection_RemoveAtInvalidIndex(int index)
        {
            var nums = new Collection<int>(1, 3, 5);

            Assert.That(() => nums.RemoveAt(index), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            nums.Clear();

            Assert.AreEqual(0, nums.Count);
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var nums = new Collection<int>(1, 3, 5, 7);

            Assert.AreEqual(InitialCapacity, nums.Capacity);
            Assert.AreEqual(4, nums.Count);
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var stringCollection = new Collection<string>();

            Assert.That(stringCollection.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var stringCollection = new Collection<string>();

            stringCollection.Add("Test");

            Assert.That(stringCollection.ToString(), Is.EqualTo("[Test]"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var stringCollection = new Collection<string>();

            stringCollection.Add("Test");
            stringCollection.Add("NewTest");

            Assert.That(stringCollection.ToString(), Is.EqualTo("[Test, NewTest]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();

            Assert.That(nestedToString, Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();

            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);

            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);

            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }
    }
}