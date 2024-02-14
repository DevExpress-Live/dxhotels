using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace HotelBookingWebFormApp {
    public class USAStates {

        private List<State> states = new List<State>();

        public ReadOnlyCollection<State> States {
            get {
                return states.AsReadOnly();
            }
        }

        public USAStates() {
            PopulateStates();
        }

        private void PopulateStates() {
            states.Add(new State("AL", "Alabama"));
            states.Add(new State("AK", "Alaska"));
            states.Add(new State("AZ", "Arizona"));
            states.Add(new State("AR", "Arkansas"));
            states.Add(new State("CA", "California"));
            states.Add(new State("CO", "Colorado"));
            states.Add(new State("CT", "Connecticut"));
            states.Add(new State("DC", "District of Columbia"));
            states.Add(new State("DE", "Delaware"));
            states.Add(new State("FL", "Florida"));
            states.Add(new State("GA", "Georgia"));
            states.Add(new State("HI", "Hawaii"));
            states.Add(new State("ID", "Idaho"));
            states.Add(new State("IL", "Illinois"));
            states.Add(new State("IN", "Indiana"));
            states.Add(new State("IA", "Iowa"));
            states.Add(new State("KS", "Kansas"));
            states.Add(new State("KY", "Kentucky"));
            states.Add(new State("LA", "Louisiana"));
            states.Add(new State("ME", "Maine"));
            states.Add(new State("MD", "Maryland"));
            states.Add(new State("MA", "Massachusetts"));
            states.Add(new State("MI", "Michigan"));
            states.Add(new State("MN", "Minnesota"));
            states.Add(new State("MS", "Mississippi"));
            states.Add(new State("MO", "Missouri"));
            states.Add(new State("MT", "Montana"));
            states.Add(new State("NE", "Nebraska"));
            states.Add(new State("NV", "Nevada"));
            states.Add(new State("NH", "New Hampshire"));
            states.Add(new State("NJ", "New Jersey"));
            states.Add(new State("NM", "New Mexico"));
            states.Add(new State("NY", "New York"));
            states.Add(new State("NC", "North Carolina"));
            states.Add(new State("ND", "North Dakota"));
            states.Add(new State("OH", "Ohio"));
            states.Add(new State("OK", "Oklahoma"));
            states.Add(new State("OR", "Oregon"));
            states.Add(new State("PA", "Pennsylvania"));
            states.Add(new State("RI", "Rhode Island"));
            states.Add(new State("SC", "South Carolina"));
            states.Add(new State("SD", "South Dakota"));
            states.Add(new State("TN", "Tennessee"));
            states.Add(new State("TX", "Texas"));
            states.Add(new State("UT", "Utah"));
            states.Add(new State("VT", "Vermont"));
            states.Add(new State("VA", "Virginia"));
            states.Add(new State("WA", "Washington"));
            states.Add(new State("WV", "West Virginia"));
            states.Add(new State("WI", "Wisconsin"));
            states.Add(new State("WY", "Wyoming"));
        }
        public class State {
            // Fields...
            private string _StateAbr;
            private string _StateName;

            /// <summary>
            /// Initializes a new instance of the State class.
            /// </summary>
            /// <param name="stateAbr"></param>
            /// <param name="stateName"></param>
            public State(string stateAbr, string stateName) {
                _StateAbr = stateAbr;
                _StateName = stateName;
            }

            public string StateName {
                get { return _StateName; }
                set {
                    _StateName = value;
                }
            }


            public string StateAbr {
                get { return _StateAbr; }
                set {
                    _StateAbr = value;
                }
            }


        }


    }
}
