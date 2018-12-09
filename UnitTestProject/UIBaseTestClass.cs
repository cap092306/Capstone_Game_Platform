using System;
using System.IO;
using System.Reflection;
using TestStack.White;

namespace UnitTestProject
{
    public abstract class UIBaseTestClass : IDisposable
    {
        public Application Application { get; private set; }

        protected UIBaseTestClass()
        {
            var directoryName = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var path = Path.Combine(directoryName, Properties.Resources.AppExeName.ToString());
            Application = Application.Launch(path);
        }

        public void Dispose()
        {
            Application.Dispose();
        }
    }
}
