using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace WorkflowConsoleApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            //Activity wf = new WriteLine
            //{
            //    Text = "Hello World."
            //};

            //WorkflowInvoker.Invoke(wf);

            //Console.WriteLine("Input age1: ");
            //var checkName = new CheckName();
            //checkName.Age = Convert.ToInt32(Console.ReadLine());
            //WorkflowInvoker.Invoke(checkName);
            //Console.ReadKey();

            Console.Write("Input age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            WorkflowInvoker.Invoke(new ConfirmWF(),
                new Dictionary<string, object>()
                {
                    { "Age", age }
                });

        }
    }
}
