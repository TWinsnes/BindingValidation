using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingValidation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public static readonly DependencyProperty BindingObjectProperty =
			DependencyProperty.Register("BindingObject", typeof (TestObject), typeof (MainWindow),
			                            new PropertyMetadata(default(TestObject)));

		public static readonly DependencyProperty BindingObject2Property =
			DependencyProperty.Register("BindingObject2", typeof (TestObject2), typeof (MainWindow),
			                            new PropertyMetadata(default(TestObject2)));

		/// <summary>
		/// Create a new MainWindow object.
		/// </summary>
		public MainWindow()
		{
			BindingObject = new TestObject {EndDate = DateTime.Now.AddDays(1), StartDate = DateTime.Now};


			BindingObject2 = new TestObject2 {EndDate = DateTime.Now.AddDays(1), StartDate = DateTime.Now};


			InitializeComponent();

			// set up first date picker pair.
			var binding = new Binding("StartDate")
			              	{Mode = BindingMode.TwoWay, Source = BindingObject, ValidatesOnExceptions = true};
			StartPicker.SetBinding(DatePicker.SelectedDateProperty, binding);

			binding = new Binding("EndDate") {Mode = BindingMode.TwoWay, Source = BindingObject, ValidatesOnExceptions = true};
			EndPicker.SetBinding(DatePicker.SelectedDateProperty, binding);


			// set up second date picker pair.
			binding = new Binding("StartDate") {Mode = BindingMode.TwoWay, Source = BindingObject2, ValidatesOnDataErrors = true};
			StartPicker2.SetBinding(DatePicker.SelectedDateProperty, binding);

			binding = new Binding("EndDate") {Mode = BindingMode.TwoWay, Source = BindingObject2, ValidatesOnDataErrors = true};
			EndPicker2.SetBinding(DatePicker.SelectedDateProperty, binding);
		}

		/// <summary>
		/// Binding object for validation on exception.
		/// </summary>
		public TestObject BindingObject
		{
			get { return (TestObject) GetValue(BindingObjectProperty); }
			set { SetValue(BindingObjectProperty, value); }
		}

		/// <summary>
		/// Binding object for validation on error using IDataErrorInfo.
		/// </summary>
		public TestObject2 BindingObject2
		{
			get { return (TestObject2) GetValue(BindingObject2Property); }
			set { SetValue(BindingObject2Property, value); }
		}
	}
}