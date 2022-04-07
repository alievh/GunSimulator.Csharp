using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.IndexerFolder
{
    public class Indexer<T>
    {
        private T[] _array;
        private static int _idCounter;

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public int Id { get; set; }

        public int Length { get => _array.Length; }

        static Indexer()
        {
            _idCounter = 0;
        }

        public Indexer()
        {
            _array = new T[0];
            Id = ++_idCounter;
        }

        /// <summary>
        /// Using for add any value
        /// </summary>
        /// <param name="input">Value which will be added</param>
        public void Add(T input)
        {

            T[] newArray = Resize(_array, _array.Length + 1);
            newArray[^1] = input;
            _array = newArray;

        }


        /// <summary>
        /// Using for remove any value
        /// </summary>
        /// <param name="input">Value which will be removed</param>
        public void Remove(T input)
        {
            bool isTrue = false;

            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (input.Equals(_array[i]))
                {
                    isTrue = true;
                }
                if (isTrue)
                {
                    _array[i] = _array[i + 1];
                }
            }
            if (input.Equals(_array[^1]))
            {
                isTrue = true;
            }
            if (isTrue)
            {
                T[] newArray = Resize(_array, _array.Length - 1);
                _array = newArray;
            }
        }

        /// <summary>
        /// Using for resize array
        /// </summary>
        /// <param name="array">Array which need to resize</param>
        /// <param name="newSize">Value which array's length will be</param>
        /// <returns></returns>
        public T[] Resize(T[] array, int newSize)
        {
            T[] newArray = new T[newSize];
            int counter = 0;

            counter = newSize > array.Length ? array.Length : newSize;

            for (int i = 0; i < counter; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;

        }

        /// <summary>
        /// Using for print all user to Console
        /// </summary>
        public void Peek()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }

    }
}
