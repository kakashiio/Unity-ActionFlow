using System;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 23:05
    //******************************************
    public class CompareCondition : ICondition
    {
        public enum Operator
        {
            Small,      //  a <  b
            NotLarge,   //  a <= b
            Equal,      //  a == b
            NotSmall,   //  a >= b
            Large       //  a >  b
        }
        
        private float _NumberA;
        private float _NumberB;
        private Operator _Operator;

        public CompareCondition(float numberA, float numberB, Operator @operator)
        {
            _NumberA = numberA;
            _NumberB = numberB;
            _Operator = @operator;
        }

        public bool Evaluate(IActionContext context)
        {
            switch (_Operator)
            {
                case Operator.Small:
                    return _NumberA < _NumberB;
                case Operator.NotLarge:
                    return _NumberA <= _NumberB;
                case Operator.Equal:
                    return _NumberA.CompareTo(_NumberB) == 0;
                case Operator.NotSmall:
                    return _NumberA >= _NumberB;
                case Operator.Large:
                    return _NumberA > _NumberB;
                default:
                    throw new NotSupportedException($"Not supported operator {_Operator}");
            }
        }
    }
}