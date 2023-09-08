namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:18
    //******************************************
    public interface ICondition
    {
        bool Evaluate(IActionContext context);
    }
}