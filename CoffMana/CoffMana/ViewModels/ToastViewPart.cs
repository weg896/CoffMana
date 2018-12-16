using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Acr.UserDialogs;

namespace CoffMana.ViewModels
{
    class ToastViewPart
    {

        public static void toastMessage(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message);
            toastConfig.SetDuration(2500);
            toastConfig.SetBackgroundColor(Color.DimGray);
            UserDialogs.Instance.Toast(toastConfig);
        }

    }
}
