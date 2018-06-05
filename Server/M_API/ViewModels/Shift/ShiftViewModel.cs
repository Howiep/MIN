using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Data.models;

namespace M_API.ViewModels.Shift {
	public class ShiftViewModel {
		public int Id { get; set; }
		public string Note { get; set; }
		public DateTime Date { get; set; }
		public List<Experience> Experiences { get; set; }
	}
}