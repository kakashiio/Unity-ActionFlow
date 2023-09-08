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
        public float GetTime()
        {
            return Time.time;
        }

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}