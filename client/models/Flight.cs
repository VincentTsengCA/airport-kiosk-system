

namespace Airport_Kiosk_System.Models {
    public enum FLIGHT_STATUS {
        AWAITING,
        BOARDING,
        DEPARTED,
        ARRIVED,
        DELAYED,
        CANCELED
    }

    public class Flight {
        public string flightNumber { get; set; }
        public FlightStopInfo departureInfo { get; set; }
        public FlightStopInfo arrivalInfo { get; set; }
        public FLIGHT_STATUS status { get; set; }

        public Flight() {}
    }
}
