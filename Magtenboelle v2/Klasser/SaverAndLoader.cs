﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Magtenboelle_v2 {
	class SaverAndLoader {
		public static void LoadCustomer() {
			JsonStringToObject(ReadFromFile("customer-json.txt"));
		}

		public static void SaveCustomer(List<Customer> customer) {
			ObjectToJsonString(customer, @"customer-json.txt");
		}


		private static String ReadFromFile(string fileName) {
			string fileString;
			StreamReader textFile;
			textFile = File.OpenText(fileName);
			fileString = textFile.ReadToEnd();
			textFile.Close();
			return fileString;
		}

		private static void WriteToFile(string text, string fileName) {
			using(StreamWriter file = new StreamWriter(fileName, false)) {
				file.Write(text);
				file.Close();
			}
		}

		private static void ObjectToJsonString(List<Customer> listObject, string fileName) {
			string source = JsonConvert.SerializeObject(listObject);
			WriteToFile(source, fileName);
		}

		private static void JsonStringToObject(String jsonString) {
			Customer.customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
		}
	}
}