using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    class StartPage : ContentPage
    {
        public StartPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();

            BoxView redBox = new BoxView { Color = Colors.Red };
            BoxView greenBox = new BoxView { BackgroundColor = Colors.Green };
            BoxView blueBox = new BoxView { BackgroundColor = Colors.Blue };

            AbsoluteLayout.SetLayoutBounds(redBox, new Rect(0.1, 0.2, 50, 80));
            // устанавливаем пропорциональные координаты
            AbsoluteLayout.SetLayoutFlags(redBox, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(greenBox, new Rect(1, 0.2, 50, 80));
            AbsoluteLayout.SetLayoutFlags(greenBox, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(blueBox, new Rect(0.4, 0.8, 0.2, 0.2));
            // пропорциональные координаты и размеры
            AbsoluteLayout.SetLayoutFlags(blueBox, AbsoluteLayoutFlags.All);

            absoluteLayout.Children.Add(redBox);
            absoluteLayout.Children.Add(greenBox);
            absoluteLayout.Children.Add(blueBox);

            Content = absoluteLayout;
        }
    }
}
