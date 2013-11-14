using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magtenboelle_v2
{
    class BBResClass : IListable
    {
        //Constructor 
        public BBResClass(DateTime date, string firstname, string lastname, string pets, string customersplans)
        {
             Firstname = firstname;
             Lastname = lastname;
             Pets = pets;
             Customersplans = customersplans;
             StartDate = startDate;
             EndDate = endDate;
             TypeRes = typeRes;
        }

        //Backend Fields
        string _firstname;
        string _lastname;
        string _pets;
        string _customersplans;
        DateTime _startDate;
        DateTime _endDate;
        string _typeRes;

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

        public string Customersplans
        {
            get { return _customersplans; }
            set { _customersplans = value; }
        }

        public string Pets
        {
            get { return _pets; }
            set { _pets = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string TypeRes
        {
            get { return _typeRes; }
            set { _typeRes = value; }
        }
    }
}
