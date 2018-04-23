Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace WpfApplication100
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            Dim customers As New ObservableCollection(Of Customer)()
            For i As Integer = 1 To 29
                customers.Add(New Customer() With {.ID = i, .Name = "Name" & i})
            Next i
            comboBox.ItemsSource = customers
        End Sub
    End Class

    Public Class Customer
        Public Property ID() As Integer

        Public Property Name() As String
    End Class
End Namespace
