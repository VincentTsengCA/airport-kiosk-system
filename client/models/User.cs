

namespace Airport_Kiosk_System.Models {
    public enum USER_TYPE { TRAVELLER, ADMIN }
    
    public class User {
        public USER_TYPE type { get; set; }
        private string? authToken { get; set; } = null;
        
        // These were changed to server side for security
        // public uint id { get; set; }
        // public string firstName { get; set; }
        // public string lastName { get; set; }
        // public DateOnly dateOfBirth { get; set; }
        // public string nationality { get; set; }
        // public string passportNumber { get; set; }

        public User() {}

        public User(USER_TYPE type, string authToken) {
            this.type = type;
            this.authToken = authToken;
        }

        public string getName() {
            string name = "";
            
            // return firstName + " " + lastName;
            return name;
        }

        public string getAuthToken() {
            if (isAuthenticated()) {
                return authToken;
            }

            return "NULL";
        }

        public bool isAuthenticated() {
            return authToken != null;
        }
    }
}
