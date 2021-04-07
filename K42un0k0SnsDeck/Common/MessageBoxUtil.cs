using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace K42un0k0SnsDeck.Common
{
    public static class MessageBoxUtil
    {
        static public MessageBoxResult ShowError(Exception err)
        {
            return MessageBox.Show(err.Message, "エラー");
        }
        static public MessageBoxResult ShowError(AggregateException err)
        {
            var errorMessages = "";
            foreach (var errInner in err.InnerExceptions)
            {
                errorMessages += errInner.Message + "\n";
            }

            return MessageBox.Show(errorMessages, "エラー");
        }
    }
}
