using System;
using System.ComponentModel;

namespace BindingValidation
{
	/// <summary>
	/// Test object containg two dates.
	/// </summary>
	public class TestObject : INotifyPropertyChanged
	{
		/// <summary>
		/// Backing field for EndDate property.
		/// </summary>
		protected DateTime _endDate;

		/// <summary>
		/// Backing field for StartDate property.
		/// </summary>
		protected DateTime _startDate;
		
		/// <summary>
		/// Start time
		/// </summary>
		/// <remarks>
		/// Have to be before end time.
		/// </remarks>
		public virtual DateTime StartDate
		{
			get { return _startDate; }
			set
			{
				if (value >= _endDate)
				{
					throw new Exception("Start date has to be before end date.");
				}
				if (_startDate == value)
				{
					return;
				}

				_startDate = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("StartDate"));
				}
			}
		}

		/// <summary>
		/// End time
		/// </summary>
		/// <remarks>
		/// Have to be after Start time.
		/// </remarks>
		public virtual DateTime EndDate
		{
			get { return _endDate; }
			set
			{
				if (value <= _startDate)
				{
					throw new Exception("End date has to be after start date.");
				}

				if (_endDate == value)
				{
					return;
				}

				_endDate = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("EndDate"));
				}
			}
		}

		#region INotifyPropertyChanged Members

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}