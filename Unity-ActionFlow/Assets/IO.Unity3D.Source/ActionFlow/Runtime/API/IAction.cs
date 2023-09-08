namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 17:57
    //******************************************
    public interface IAction
    {
        bool Execute(IActionContext context);

        void Start(IActionContext context);
        
        void End(IActionContext context);
    }
}