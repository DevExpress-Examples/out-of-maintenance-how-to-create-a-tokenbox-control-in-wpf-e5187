Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace TokenBoxExample
	Public Class TokenBox
		Inherits ComboBoxEdit
        Public Shared ReadOnly TokenizedSelectedItemsProperty As DependencyProperty = DependencyProperty.Register("TokenizedSelectedItems", GetType(ObservableCollection(Of Object)), GetType(TokenBox), New UIPropertyMetadata(AddressOf TokenizedSelectedItemsPropertyChanged))
		Public Property TokenizedSelectedItems() As ObservableCollection(Of Object)
			Get
				Return CType(GetValue(TokenizedSelectedItemsProperty), ObservableCollection(Of Object))
			End Get
			Set(ByVal value As ObservableCollection(Of Object))
				SetValue(TokenizedSelectedItemsProperty, value)
			End Set
		End Property
		Private Shared Sub TokenizedSelectedItemsPropertyChanged(ByVal source As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
		End Sub

		Public Sub New()
			TokenizedSelectedItems = New ObservableCollection(Of Object)()
			RemoveItemCommand = New DelegateCommand(Of Object)(AddressOf RemoveItem)
			AddHandler Me.EditValueChanged, AddressOf TokenBox_EditValueChanged
		End Sub

		Private Sub TokenBox_EditValueChanged(ByVal sender As Object, ByVal e As EditValueChangedEventArgs)
			If e.NewValue IsNot Nothing AndAlso (Not TokenizedSelectedItems.Contains(e.NewValue)) Then
				TokenizedSelectedItems.Add(e.NewValue)
			End If
			Me.EditValue = Nothing
		End Sub

		Private privateRemoveItemCommand As ICommand
		Public Property RemoveItemCommand() As ICommand
			Get
				Return privateRemoveItemCommand
			End Get
			Set(ByVal value As ICommand)
				privateRemoveItemCommand = value
			End Set
		End Property
		Private Sub RemoveItem(ByVal item As Object)
			TokenizedSelectedItems.Remove(item)
		End Sub
	End Class

	Public Class WrapTokenPanel
		Inherits Panel
		Public Shared ReadOnly EditElementMinWidthProperty As DependencyProperty = DependencyProperty.Register("EditElementMinWidth", GetType(Double), GetType(WrapTokenPanel), New FrameworkPropertyMetadata(0R, FrameworkPropertyMetadataOptions.AffectsMeasure, Nothing))
		Public Property EditElementMinWidth() As Double
			Get
				Return CDbl(GetValue(EditElementMinWidthProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(EditElementMinWidthProperty, value)
			End Set
		End Property

		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			If Children.Count < 2 Then
				Return MyBase.MeasureOverride(availableSize)
			End If
			Children(0).Measure(New Size(Math.Max(availableSize.Width - EditElementMinWidth, 0), Double.PositiveInfinity))
			Children(1).Measure(New Size(availableSize.Width - Children(0).DesiredSize.Width, Double.PositiveInfinity))
			Return New Size(availableSize.Width, Math.Max(Children(0).DesiredSize.Height, Children(1).DesiredSize.Height))
		End Function
		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			If Children.Count < 2 Then
				Return MyBase.ArrangeOverride(finalSize)
			End If
			Dim rightChildWidth As Double = Math.Max(finalSize.Width - Children(0).DesiredSize.Width, EditElementMinWidth)
			Children(0).Arrange(New Rect(New Size(Children(0).DesiredSize.Width, finalSize.Height)))
			Children(1).Arrange(New Rect(New Point(Children(0).DesiredSize.Width, 0), New Size(rightChildWidth, finalSize.Height)))
			Return MyBase.ArrangeOverride(finalSize)
		End Function
	End Class
End Namespace
