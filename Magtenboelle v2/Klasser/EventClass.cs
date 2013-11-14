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
        public EventClass(string eventName, DateTime startDate, DateTime endDate, int numberOfParticipant, double pricePrPerson)
        {
            Name = eventName;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfParticipant = numberOfParticipant;
            PricePrPerson = pricePrPerson;
        }

        //backend fields
        int _id;
        string _name;
        DateTime _startDate;
        DateTime _endDate;
        int _numberOfParticipant;
        double _pricePrPerson;

        //property with backend fields
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
