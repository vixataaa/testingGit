using System;
using System.Text;

namespace GenericList
{
    public static class Calculations
    {
        public static int GreaterPowOf2(int number)
        {
            int result;
            int pow = 0;

            while (number > 0)
            {
                number >>= 1;
                pow++;
            }

            result = 1 << pow;

            return result;
        }   //get the nearest power of 2(ex. of 40 is 64)
    }   //contains some calculating methods used in the class GenericList

    public class GenericList<T>
        where T : IComparable<T>
    {
        private Exception outOfRange = new System.ArgumentOutOfRangeException("index", "index is out of range");
        //exception to throw when invalid index is tried

        private T[] elements;

        public int Count { private set; get; }  //number of elements
        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }   //capacity, how many elements can the list contain

        public GenericList()
        {
            this.Count = 0;
            this.elements = new T[2];
        }   //parameterless constructor
        public GenericList(int capacity)
        {
            this.Count = 0;
            this.elements = new T[Calculations.GreaterPowOf2(capacity)];
        }   //constructor, takes capacity as parameter and makes the private array with size nearest higher power of 2

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Expand();
            }   //resizes array if needed

            this.elements[Count] = item;
            this.Count++;
        }   //adds an element, expands private array if needed

        public T this[int index]
        {
            get
            {
                if(index > this.Count - 1)
                {
                    throw outOfRange;
                }
                return this.elements[index];
            }
            set
            {
                if (index > this.Count - 1)
                {
                    throw outOfRange;
                }
                this.elements[index] = value;
            }
        }   //indexer

        public void RemoveAt(int index)
        {
            if(index > this.Count - 1)
            {
                throw outOfRange;
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }//moves elements from the deleted to the left

            this.elements[this.Count - 1] = default(T);//no longer needed, moved 1 position backwards

            this.Count--;
        }//removes element at given index, go back here to fix resizing

        public void InsertAt(int index, T item)
        {
            if(index > this.Count - 1)
            {
                throw outOfRange;
            }

            if (this.Count == this.Capacity)
            {
                this.Expand();
            }

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.elements[i + 1] = this.elements[i];
            }//moves elements right

            this.elements[index] = item;
            this.Count++;
        }   //inserts element at given position


        public void Clear()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.elements[i] = default(T);
            }   //clears all elements(sets them to their default value)

            this.Count = 0;
        }   //clear the list


        public int IndexOf(T item)
        {
            int index = -1; //value to return if the element is not found

            for(int i = 0; i < this.Count - 1; i++)
            {
                if(this.elements[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }   //find element by value

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < this.Count; i++)
            {
                result.Append(this.elements[i]);
                if(i < this.Count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }   //ToString() override, returns elements of the array separated by comma

        private void Expand()
        {
            T[] expandedArray = new T[this.Capacity * 2];
            for (int i = 0; i < this.Count; i++)
            {
                expandedArray[i] = this.elements[i];
            }

            this.elements = expandedArray;
        }//makes new array double the size, copies old elements to it }

    }
}
