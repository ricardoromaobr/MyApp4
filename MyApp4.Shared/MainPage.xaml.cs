using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SkiaSharp.Views.UWP;
using SkiaSharp;
using Windows.Graphics.Display;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyApp4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static DependencyProperty PointerMovedValueProperty = 
            DependencyProperty.Register(nameof(PointerMovedValue), typeof(string), 
                typeof(MainPage), new PropertyMetadata(default(string)));

        public static DependencyProperty PointerPressedValueProperty = 
            DependencyProperty.Register(nameof(PointerPressedValue), typeof(string), typeof(MainPage),
                new PropertyMetadata(default(string)));

        SKPoint _point;
        bool _draw = false;
        SKColor _color = SKColors.Red;
        public MainPage()
        {
            this.InitializeComponent();
        }

        public string PointerMovedValue
        {
            get => (string)GetValue(PointerMovedValueProperty);
            set => SetValue(PointerMovedValueProperty, value);
        }

        public string PointerPressedValue
        {
            get => (string)GetValue(PointerPressedValueProperty);
            set => SetValue(PointerPressedValueProperty, value);
        }

        private void Rectangle_PoiterMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerMovedValue = e.GetCurrentPoint(Workbench).Position.ToString();
        }

        private void Rectangle_PoiterPressed(object sender, PointerRoutedEventArgs e)
        {
            var pointer = e.GetCurrentPoint(Workbench).Position;
            PointerPressedValue = pointer.ToString();
            _point.X = (float)pointer.X;
            _point.Y = (float)pointer.Y;

            _draw = true;
            Workbench.Invalidate();
        }

        private void BtnRed_Clicked(object sender, RoutedEventArgs e)
        {
            _color = SKColors.Red;
        }

        private void BtnBlue_Clicked(object sender, RoutedEventArgs e)
        {
            _color = SKColors.Blue;
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            var display = DisplayInformation.GetForCurrentView();
            var scale = display.LogicalDpi / 96.0f;
            var size = new SKSize(e.Info.Width, e.Info.Height);
            var scaledSize = new SKSize((float)size.Width / scale, (float)size.Height / scale);

            canvas.Scale(scale);

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = _color
                
            };

            if (_draw)
                canvas.DrawCircle(_point, 10, paint);
        }
    }
}
