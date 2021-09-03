<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128644522/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5187)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


