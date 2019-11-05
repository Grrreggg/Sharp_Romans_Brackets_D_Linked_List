using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_Romans_IX()
        {
            // Arrange
            string romans = "IX";
            int expected = 9;
            int actual = 0;

            ToIntRe RomanToIntClass = new ToIntRe();

            // Act
            actual = RomanToIntClass.RomanToInt(romans);

            // Assert
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Check_Brackets()
        {
            // Arrange
            string brackets = "()()";
            bool actual;

            Balance BalanceClass = new Balance();

            // Act
            actual = BalanceClass.Check(brackets);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Add_To_D_Linked_List()
        {
            // Arrange
            string elment_0 = "Ivan";

            DoubleLinkedList<string> linkedList = new DoubleLinkedList<string>();

            // Act
            linkedList.AddLast(elment_0);
     
            // Assert
            Assert.IsTrue(linkedList.Contains(elment_0));
        }

        [TestMethod]
        public void Reverse_D_Linked_List()
        {
            // Arrange
            string elment_0 = "A";
            string elment_1 = "B";
            string elment_2 = "C";
            string expected = "CBA";
            string actual = "";

            DoubleLinkedList<string> linkedList = new DoubleLinkedList<string>();

            // Act
            linkedList.AddLast(elment_0);
            linkedList.AddLast(elment_1);
            linkedList.AddLast(elment_2);

            linkedList.Reverse();

            foreach (var item in linkedList)
            {
                actual += item;
            }

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }

}