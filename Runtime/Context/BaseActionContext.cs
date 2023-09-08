using System;
using System.Collections.Generic;
using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow.Runtime
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 19:05
    //******************************************
    public class BaseActionContext : IActionContext
    {
        private Dictionary<Type, object> _Data = new ();
        
        public float GetTime()
        {
            return Time.time;
        }

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        public T Get<T>()
        {
            var type = typeof(T);
            if (_Data.TryGetValue(type, out object o))
            {
                return (T)o;
            }
            return default;
        }
        
        public void Set<T>(T t)
        {
            var type = typeof(T);
            if (_Data.ContainsKey(type))
            {
                _Data[type] = t;
            }
            else
            {
                _Data.Add(type, t);
            }
        }
    }
}