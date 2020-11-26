using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ContactLib;
//using ContactLibSQL;
using Ninject.Web.Common;

namespace Lab2.DI
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IContactContext<Contact>>().To<ContactContext>(); // TASK 1 - новый экземпляр на каждый вызов

            //Bind<IContactContext<Contact>>().To<ContactContext>().InThreadScope();  //TASK 2 - новый экземпляр на каждый поток

            //Bind<IContactContext<Contact>>().To<ContactContext>().InRequestScope(); //TASK 3 - новый экземпляр на каждый HTTP-запрос
        }
    }
}