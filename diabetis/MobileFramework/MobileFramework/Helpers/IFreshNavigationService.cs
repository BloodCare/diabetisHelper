﻿using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FreshMvvm
{
    public interface IFreshNavigationService
    {
        Task PopToRoot(bool animate = true);

		Task PushPage (Page page, FreshBasePageModel model, bool modal = false, bool animate = true);

		Task PopPage (bool modal = false, bool animate = true);
    }
}

