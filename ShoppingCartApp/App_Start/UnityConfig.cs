using BusinessLayer.Interface;
using BusinessLayer.services;
using RepositeryLayer.Interface;
using RepositeryLayer.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ShoppingCartApp.App_Start
{
    public class unityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService,C:\Users\dell\source\repos\ShoppingCartApp\ShoppingCartApp\Scripts\ TestService>();
            container.RegisterType<IProductsBusinessLayer, ProductBusinessLayer>();
            container.RegisterType<IProductRepositeryLayer, ProductRepositeryLayer>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}