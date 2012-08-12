using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BindingValidation
{
	public class TestObject2 : TestObject, IDataErrorInfo
	{
		/// <summary>
		/// Contains the error for the implementation of IDataErrorInfo.
		/// </summary>
		private string _lastError = "";
		
		/// <summary>
		/// End time
		/// </summary>
		/// <remarks>
		/// Have to be after Start time.
		/// </remarks>
		public override DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDate = value;
			}
		}

		/// <summary>
		/// Start time
		/// </summary>
		/// <remarks>
		/// Have to be before end time.
		/// </remarks>
		public override DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDate = value;
			}
		}

		#region IDataErrorInfo Members

		/// <summary>
		/// Gets the error message for the property with the given name.
		/// </summary>
		/// <returns>
		/// The error message for the property. The default is an empty string ("").
		/// </returns>
		/// <param name="columnName">The name of the property whose error message to get. </param>
		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case ("StartDate"):
						{
							if (StartDate >= EndDate)
							{
								_lastError = "Start date have to be before end date.";
							}
							else
							{
								_lastError = string.Empty;
							}
							break;
						}
					case ("EndDate"):
						{
							if (EndDate <= StartDate)
							{
								_lastError = "End date have to be after start date.";
							}
							else
							{
								_lastError = string.Empty;
							}
							break;
						}
					default:
						_lastError = string.Empty;
						break;

				}

				return _lastError;
			}
		}

		/// <summary>
		/// Gets an error message indicating what is wrong with this object.
		/// </summary>
		/// <returns>
		/// An error message indicating what is wrong with this object. The default is an empty string ("").
		/// </returns>
		public string Error
		{
			get { return _lastError; }
		}

		#endregion
	}
}