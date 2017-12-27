using System;
using Windows.UI.Popups;

namespace RegistarPacijenataUWP
{
    public static class MsgBox
    {
        static public async void Show()
        {
            var msgbox = new MessageDialog("Da li želite unesti još podataka?", "Unos uspješan");
            msgbox.Commands.Clear();
            msgbox.Commands.Add(new UICommand { Label = "Da", Id = 0 });
            msgbox.Commands.Add(new UICommand { Label = "Ne", Id = 1 });

            var res = await msgbox.ShowAsync();

            if ((int)res.Id == 0)
            {
                
            }

            if ((int)res.Id == 1)
            {
                App.Current.Exit();
            }
                        
        }

        static public async void Show(string tekst, string naslov)
        {
            var msgbox = new MessageDialog(tekst, naslov);
            msgbox.Commands.Clear();
            msgbox.Commands.Add(new UICommand { Label = "U redu", Id = 0 });
            
            var res = await msgbox.ShowAsync();

            if ((int)res.Id == 0)
            {

            }

        }
    }
}

