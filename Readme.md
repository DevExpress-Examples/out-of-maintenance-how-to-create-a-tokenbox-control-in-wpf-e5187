<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/WpfApplication100/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication100/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication100/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication100/MainWindow.xaml.vb))
<!-- default file list end -->
# How to create a TokenBox control in WPF


<p>Starting with version 14.2, TokenBox is available out of the box. To activate it, use TokenComboBoxStyleSettings in ComboBoxEdit:</p>


```xaml
        <dxe:ComboBoxEdit>
            <dxe:ComboBoxEdit.StyleSettings>
                <dxe:TokenComboBoxStyleSettings/>
            </dxe:ComboBoxEdit.StyleSettings>
        </dxe:ComboBoxEdit>
```


<p> </p>
<p><em>For version 14.1 and older:</em><br />The main idea of the demonstrated approach is to use the ComboBoxEdit.EditTemplate property and put an ItemsControl into the edit area. In the ItemsControl, the ItemTemplate property is used to display selected items as a TextBlock with the "Cross" button. To wrap selected items, a Panel descendant was created. This descendant implements its own measuring and arranging mechanism.</p>

<br/>


