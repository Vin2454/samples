using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class EmployeeDepartmentHistoryModel
	{
		public EmployeeDepartmentHistoryModel()
		{}
		public EmployeeDepartmentHistoryModel(short departmentID,
		                                      int shiftID,
		                                      DateTime startDate,
		                                      Nullable<DateTime> endDate,
		                                      DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private short _departmentID;
		[Required]
		public short DepartmentID
		{
			get
			{
				return _departmentID;
			}
			set
			{
				this._departmentID = value;
			}
		}

		private int _shiftID;
		[Required]
		public int ShiftID
		{
			get
			{
				return _shiftID;
			}
			set
			{
				this._shiftID = value;
			}
		}

		private DateTime _startDate;
		[Required]
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				this._startDate = value;
			}
		}

		private Nullable<DateTime> _endDate;
		public Nullable<DateTime> EndDate
		{
			get
			{
				return _endDate.IsEmptyOrZeroOrNull() ? null : _endDate;
			}
			set
			{
				this._endDate = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e28f728e6428d19c6c7204409fe81d98</Hash>
</Codenesium>*/