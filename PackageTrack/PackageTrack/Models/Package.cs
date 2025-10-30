using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrack.Models
{
    public class PackageEvent
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
    public class Package
    {
        public string Id { get; set; }
        public string Status { get; set; } = "Em processamento";
        public DateTime ShippedDate { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public string CurrentLocation { get; set; }

        public ObservableCollection<PackageEvent> History { get; set; } = new();

    }
}
