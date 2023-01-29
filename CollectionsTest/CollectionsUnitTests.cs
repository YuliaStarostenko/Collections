using Collections;

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
        public void Test_Collections_Add()
        {
            var nums = new Collection<double>();

            nums.Add(1.5);
            nums.Add(2);

            Assert.That(nums.ToString(), Is.EqualTo("[1.5, 2]"));
        }



        //public void Test_Collection_AddWithGrow() { … }
        //public void Test_Collection_AddRange() { … }
        //public void Test_Collection_GetByIndex() { … }
        //public void Test_Collection_GetByInvalidIndex() { … }
        //public void Test_Collection_SetByIndex() { … }
        //public void Test_Collection_SetByInvalidIndex() { … }
        //public void Test_Collection_AddRangeWithGrow() { … }
        //public void Test_Collection_InsertAtStart() { … }
        //public void Test_Collection_InsertAtEnd() { … }
        //public void Test_Collection_InsertAtMiddle() { … }
        //public void Test_Collection_InsertAtWithGrow() { … }
        //public void Test_Collection_InsertAtInvalidIndex() { … }
        //public void Test_Collection_ExchangeMiddle() { … }
        //public void Test_Collection_ExchangeFirstLast() { … }
        //public void Test_Collection_ExchangeInvalidIndexes() { … }
        //public void Test_Collection_RemoveAtStart() { … }
        //public void Test_Collection_RemoveAtEnd() { … }
        //public void Test_Collection_RemoveAtMiddle() { … }
        //public void Test_Collection_RemoveAtInvalidIndex() { … }
        //public void Test_Collection_RemoveAll() { … }
        //public void Test_Collection_Clear() { … }
        //public void Test_Collection_CountAndCapacity() { … }
        //public void Test_Collection_ToStringEmpty() { … }
        //public void Test_Collection_ToStringSingle() { … }
        //public void Test_Collection_ToStringMultiple() { … }
        //public void Test_Collection_ToStringNestedCollections() { … }
        //public void Test_Collection_1MillionItems() { … }

    }
}