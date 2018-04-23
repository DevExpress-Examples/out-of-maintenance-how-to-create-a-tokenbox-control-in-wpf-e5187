using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TokenBoxExample
{
    public class TokenBox : ComboBoxEdit
    {
        public static readonly DependencyProperty TokenizedSelectedItemsProperty = DependencyProperty.Register("TokenizedSelectedItems", typeof(ObservableCollection<object>), typeof(TokenBox), new UIPropertyMetadata(TokenizedSelectedItemsPropertyChanged));
        public ObservableCollection<object> TokenizedSelectedItems
        {
            get { return (ObservableCollection<object>)GetValue(TokenizedSelectedItemsProperty); }
            set { SetValue(TokenizedSelectedItemsProperty, value); }
        }
        private static void TokenizedSelectedItemsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e) { }

        public TokenBox()
        {
            TokenizedSelectedItems = new ObservableCollection<object>();
            RemoveItemCommand = new DelegateCommand<object>(RemoveItem);
            this.EditValueChanged += TokenBox_EditValueChanged;
        }

        void TokenBox_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if (e.NewValue != null && !TokenizedSelectedItems.Contains(e.NewValue))
                TokenizedSelectedItems.Add(e.NewValue);
            this.EditValue = null;
        }

        public ICommand RemoveItemCommand
        {
            get;
            set;
        }
        void RemoveItem(object item)
        {
            TokenizedSelectedItems.Remove(item);
        }
    }

    public class WrapTokenPanel : Panel
    {
        public static readonly DependencyProperty EditElementMinWidthProperty = DependencyProperty.Register("EditElementMinWidth", typeof(double), typeof(WrapTokenPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure, null));
        public double EditElementMinWidth
        {
            get { return (double)GetValue(EditElementMinWidthProperty); }
            set { SetValue(EditElementMinWidthProperty, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count < 2)
                return base.MeasureOverride(availableSize);
            Children[0].Measure(new Size(Math.Max(availableSize.Width - EditElementMinWidth, 0), double.PositiveInfinity));
            Children[1].Measure(new Size(availableSize.Width - Children[0].DesiredSize.Width, double.PositiveInfinity));
            return new Size(availableSize.Width, Math.Max(Children[0].DesiredSize.Height, Children[1].DesiredSize.Height));
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count < 2)
                return base.ArrangeOverride(finalSize);
            double rightChildWidth = Math.Max(finalSize.Width - Children[0].DesiredSize.Width, EditElementMinWidth);
            Children[0].Arrange(new Rect(new Size(Children[0].DesiredSize.Width, finalSize.Height)));
            Children[1].Arrange(new Rect(new Point(Children[0].DesiredSize.Width, 0), new Size(rightChildWidth, finalSize.Height)));
            return base.ArrangeOverride(finalSize);
        }
    }
}
