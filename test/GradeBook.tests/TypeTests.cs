using System;
using Xunit;

namespace GradeBook.tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);

        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        //wont use  ref very often()
        public void CSharpCanPassByRef()
        {
            //arange test data 
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Test Name");
            Assert.Equal("New Test Name", book1.Name);

        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);

        }



        [Fact]
        public void CSharpIsPassByValue()
        {
            //arange test data 
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Test Name");
            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arange test data 
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        [Fact]
        public void TwoVarsCanRefernceSameObject()
        {
            //arange test data 
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arange test data 
            var book1 = GetBook("Book 1");
            SetName(book1, "New Test Name");
            Assert.Equal("New Test Name", book1.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        Book GetBook(string name)
        {

            return new Book(name);
        }
    }
}
