﻿using System;
using Xamarin.Forms;

namespace FreshMvvm
{
    /// <summary>
    /// searches in assembly for corresponding ViewModel and pages and creates 
    /// BindingContext, Eventwire, etc.
    /// </summary>
    public static class FreshPageModelResolver
    {
        public static Page ResolvePageModel<T> () where T : FreshBasePageModel
        {
            return ResolvePageModel<T> (null);
        }

        public static Page ResolvePageModel<T> (object initData) where T : FreshBasePageModel
        {
            var pageModel = FreshIOC.Container.Resolve<T> ();

            return ResolvePageModel<T> (initData, pageModel);
        }

        public static Page ResolvePageModel<T> (object data, T pageModel) where T : FreshBasePageModel
        {
            var type = pageModel.GetType ();
            var name = type.AssemblyQualifiedName.Replace ("Model", string.Empty);
            var pageType = Type.GetType (name);
            if (pageType == null)
                throw new Exception (name + " not found");

            var page = (Page)FreshIOC.Container.Resolve (pageType);

            page.BindingContext = pageModel;
            pageModel.WireEvents (page);
            pageModel.CurrentPage = page;
			pageModel.CoreMethods = new PageModelCoreMethods (page, pageModel);
            pageModel.Init (data);

            return page;
        }

    }
}

