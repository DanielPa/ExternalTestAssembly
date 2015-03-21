using System;
using System.Reflection;
using System.Windows.Forms;

namespace ExternalTestAssembly
{
    public class Script
    {
        [Start]
        public void Run()
        {
            //AbsoluteAssemblyPath: for example "C:\Users\Public\EPLAN\Data\Binaries\MyWPFControlLibrary.dll
            Assembly myAssembly = Assembly.LoadFrom(@"AbsoluteAssemblyPath");

            //Namespace.ClassName: absolute name of the class to instaciate 
            //"InstAttibute": if the constructor of the class needs some attributes
            Object objectOfTestClass = myAssembly.CreateInstance("Namespace.ClassName", false, BindingFlags.ExactBinding, null, new Object[] {"InstAttibute"}, null, null);

            //Namespace.ClassName: again the class name to get the methode to execute
            //MethodName: Name of the method to execute
            MethodInfo show = myAssembly.GetType("Namespace.ClassName").GetMethod("MethodName");

            //result: remove if methode has no return type (void)
            //"MethodAttribute": attributes for the methode (could also be empty)
            Boolean result = (Boolean)show.Invoke(objectOfTestClass, new Object[]{ "MethodAttribute" });

            //go on with simple scriptcode
            if (result == true)
            {
                MessageBox.Show("Welcome to wonderland!");
            }
            else
            {
                MessageBox.Show("So you're not the chosen one!");
            }
            
        }
    }
}
