using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    /// <summary>
    /// Класс динамической коллекции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicArray<T> : IEnumerable<T>
    {
        private static readonly int _arraySize = 8;
        private T[] _array;

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public DynamicArray()
        {
            ProjectSection section = (ProjectSection)ConfigurationManager.GetSection("DefaultValueCapacity");
            if (section == null)
            {
                _array = new T[_arraySize];
                Capacity = _arraySize;
            }
            else
            {
                _array = new T[section.CapacityValue.IntDefaultCapacity];
            }
        }

        /// <summary>
        /// Контруктор
        /// </summary>
        /// <param name="capacity">изначальная емкость</param>
        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
            Capacity = capacity;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="list">список значений</param>
        public DynamicArray(IEnumerable<T> list)
        {
            int numberElement = 0;
            int length = list.Count();

            _array = new T[length];
            foreach(var item in list)
            {
                _array[numberElement] = item;
                numberElement += 1;
            }
            Length = length;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Длина массива
        /// </summary>
        public int Length
        {
            get;
            private set;
        }

        /// <summary>
        /// Ёмкость 
        /// </summary>
        public int Capacity
        {
            get
            {
                return _array.Length;
            }
            private set{}
        }



        #endregion


        #region Methods

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="value">значение элемента</param>
        public void Add(T value)
        {
            if (Capacity <= Length)
                Array.Resize(ref _array, Capacity * 2);
            _array[Length] = value;
            Length++;
        }

        /// <summary>
        /// Добавления списка элементов
        /// </summary>
        /// <param name="list">список элементов</param>
        public void AddRange(IEnumerable<T> list)
        {
            int length = 0;
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    length++;
            }
            int freeItems = Capacity-Length;
            if (freeItems < length)
            {
                Array.Resize(ref _array, Capacity + length);
                Capacity = Capacity + length;
            }
            foreach (var item in list)
            {
                _array[Length] = item;
                Length++;
            }

        }

        /// <summary>
        /// Удаление элемента (Будут удалены из списка все элементы)
        /// </summary>
        /// <param name="item">удаляемый элемент</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            try
            {
                for (int i=0; i< Length; i++)
                {
                    if (item.Equals(_array[i]))
                        RemoveAt(i);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="index"></param>
        private void RemoveAt(int index)
        {

                T[] newArray = _array;
                int length = Length;
                for (int i = index; i <= length - 1; i++)
                {
                    _array[i] = newArray[i + 1];
                }
                _array[length - 1] = default(T);
                Length--;
        }

        /// <summary>
        /// Добавление элемента в произвольную позицию массива
        /// </summary>
        /// <param name="value">элемент</param>
        /// <param name="index">индекс позиции</param>
        /// <returns></returns>
        public bool Insert(T value, int index)
        {
            int length = Length;
            if (index > length - 1)
                throw new ArgumentOutOfRangeException();
            try
            {
                T[] newArray= _array;

                if (Capacity <= Length)
                    Array.Resize(ref _array, Capacity * 2);

                _array[index] = value;
                for (int i = index; i <= length-1; i++)
                {
                    _array[i + 1] = newArray[i];
                }
                Length++;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion 

        #region Indexer

        public T this[int index]
        { 
            get
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException();
                _array[index] = value;
            }

        }
        #endregion


        public IEnumerator<T> GetEnumerator()
        {
            Enumarations enumerator = new Enumarations(_array, Length);
            enumerator.Reset();
            while (enumerator.MoveNext())
                yield return (T)enumerator.Current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        class Enumarations : IEnumerator<T>
        {
            private int _curIndex;
            private T _current;
            private T[] _array;


            public Enumarations(T[] array, int length)
            {
                _array = (T[])array;
                Length = length;
            }
            private T CurrentItem
            {
                get { return _current; }
            }

            public int Length
            {
                get;
                private set;
            }

            public object Current
            {
                get { return CurrentItem; }
            }

            public bool MoveNext()
            {
                if (++_curIndex >= Length)
                {
                    return false;
                }
                else
                {
                    _current = _array[_curIndex];
                }
                return true;
            }

            public void Reset()
            {
                _curIndex = -1;
            }

            T IEnumerator<T>.Current
            {
                get { return (T)Current; }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
