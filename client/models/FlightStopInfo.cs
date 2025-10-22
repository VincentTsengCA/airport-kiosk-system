

namespace Airport_Kiosk_System.Models {
    public class FlightStopInfo {
        public string airportCode { get; set; }
        public string gateCode { get; set; }
        public Location location { get; set; }
        public DateTime time { get; set; }

        public FlightStopInfo() { }
    }
}
