Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace WpfApplication100

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim customers As ObservableCollection(Of Customer) = New ObservableCollection(Of Customer)()
            For i As Integer = 1 To 30 - 1
                customers.Add(New Customer() With {.ID = i, .Name = "Name" & i})
            Next

            Me.comboBox.ItemsSource = customers
        End Sub
    End Class

    Public Class Customer

        Public Property ID As Integer

        Public Property Name As String
    End Class
End Namespace
