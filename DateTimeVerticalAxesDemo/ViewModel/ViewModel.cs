using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeVerticalAxesDemo
{
	public class ViewModel
	{
		public ObservableCollection<Model> Data { get; set; }

		public double Minimum { get; set; }

		public ViewModel()
		{
			// Converting date time value to its respective double value.
			Data = new ObservableCollection<Model>()
			{
				new Model(){Name = "Jack", CheckInTime = new DateTime(2022, 11, 8, 14, 30, 0)},
				new Model(){Name = "Drake", CheckInTime = new DateTime(2022, 11, 8, 10, 0, 0)},
				new Model(){Name = "Aron", CheckInTime = new DateTime(2022, 11, 8, 15, 45, 0)},
				new Model(){Name = "John", CheckInTime = new DateTime(2022, 11, 8, 11, 25, 0)},
				new Model(){Name = "Shawn", CheckInTime = new DateTime(2022, 11, 8, 13, 10, 0)},
			};

			Minimum = new DateTime(2022, 11, 8).ToOADate();
		}
	}

	public class Model
	{
		private DateTime checkInTime;
		public string Name { get; set; }
		public double CheckIn { get; set; }
		 public DateTime CheckInTime
		{
			get { return checkInTime; }
			set
			{
				checkInTime = value;
				CheckIn = value.ToOADate();
			}
		}
	}
}
