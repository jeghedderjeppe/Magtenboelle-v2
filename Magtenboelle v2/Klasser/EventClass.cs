using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magtenboelle_v2
{
    class EventClass : IListable
    {
        //constructor
        public EventClass(string eventName, DateTime startDate, DateTime endDate, string eventDescription, int numberOfParticipant, double pricePrPerson)
        {
            EventName = eventName;
            StartDate = startDate;
            EndDate = endDate;
            EventDescription = eventDescription;
            NumberOfParticipant = numberOfParticipant;
            PricePrPerson = pricePrPerson;
        }

        //backend fields
        int _id;
        string _eventName;
        DateTime _startDate;
        DateTime _endDate;
        string _eventDescription;
        int _numberOfParticipant;
        double _pricePrPerson;

        //property with backend fields
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public string EventDescription
        {
            get { return _eventDescription; }
            set { _eventDescription = value; }
        }
        public int NumberOfParticipant
        {
            get { return _numberOfParticipant; }
            set { _numberOfParticipant = value; }
        }
        public double PricePrPerson
        {
            get { return _pricePrPerson; }
            set { _pricePrPerson = value; }
        }
    }
}
