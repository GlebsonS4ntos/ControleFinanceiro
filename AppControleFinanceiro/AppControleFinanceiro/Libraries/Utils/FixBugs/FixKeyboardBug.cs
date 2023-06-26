using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Platform;

namespace AppControleFinanceiro.Libraries.Utils.FixBugs
{
    public class FixKeyboardBug
    {
        public static void HideKeyboard()
        {
#if ANDROID
            if (Platform.CurrentActivity.CurrentFocus != null)
            {
                Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
            }
#endif
        }
    }
}
