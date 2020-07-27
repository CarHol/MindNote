using MindNote.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MindNote
{
    public class NoteCell : ViewCell
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(NoteCell), "");

        
        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue (TextProperty, value); }
        }

        public static readonly BindableProperty LongpressCommandProperty =
            BindableProperty.Create(nameof(LongpressCommand), typeof(ICommand), typeof(NoteCell), null);

        public ICommand LongpressCommand {
            get { return (ICommand)GetValue(LongpressCommandProperty); }
            set { SetValue(LongpressCommandProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NoteCell), null);

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(NoteCell), (object)null);

        public object CommandParameter {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>  
        /// Exposes handler for long press events. Method provided by Muhammad Zubair.
        public event EventHandler LongPressed {
            add { LongPressedHandler += value; }
            remove { LongPressedHandler -= value; }
        }
        public EventHandler LongPressedHandler;

        /// <summary>  
        /// Included for the possibility of future use.  Method provided by Muhammad Zubair.
        /// </summary>  
        public event EventHandler Tapped {
            add { TappedHandler += value; }
            remove { TappedHandler -= value; }
        }
        public EventHandler TappedHandler;

        /*
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create("Date", typeof(DateTime), typeof(NoteCell), "");

        public DateTime Date {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        */


    }
}
