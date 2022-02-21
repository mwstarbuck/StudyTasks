using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Ninject;
using StudyTasks.DAL;

namespace DatabaseUtiliies
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProvideStudyTasks>().To<StudyTasksProvider>();
            

        }
    }
}
