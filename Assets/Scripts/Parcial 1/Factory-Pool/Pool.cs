using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Factory.Pool
{
    public class Pool<T>
    {
        private Func<T> _factoryMethod;

        private Action<T> _turnOnCallBack;
        private Action<T> _turnOffCallBack;

        private List<T> _currentStock;

        public Pool(Func<T> factoryMethod, Action<T> turnOnCallBack, Action<T> turnOffCallBack, int initialAmount)
        {
            _currentStock = new List<T>();

            _factoryMethod = factoryMethod;
            _turnOnCallBack = turnOnCallBack;
            _turnOffCallBack = turnOffCallBack;

            for (int i = 0; i < initialAmount; i++)
            {
                T obj = _factoryMethod();

                _turnOffCallBack(obj);

                _currentStock.Add(obj);
            }
        }

        public T GetObject()
        {
            T result;

            if (_currentStock.Count == 0)
            {
                result = _factoryMethod();
            }
            else
            {
                result = _currentStock[0];
                _currentStock.RemoveAt(0);
            }

            _turnOnCallBack(result);

            return result;
        }

        public void ReturnObjectToPool(T obj)
        {
            _turnOffCallBack(obj);
            _currentStock.Add(obj);
        }
    }
}
