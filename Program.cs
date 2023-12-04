using SerializationDeserializationAssignment_26;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDeserializationAssignment_26
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // Binary Serialization and Deserialization
            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Ritesh",
                LastName = "Bhardwaj",
                Salary = 50000.0
            };
            // Binary Serialization
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\\mphasis-B2\\Day-21\\SerializationDeserializationAssignment-26\\employee.txt",
            FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, employee);
            stream.Close();

            // Binary Deserialization
            stream = new FileStream(@"C:\\mphasis-B2\\Day-21\\SerializationDeserializationAssignment-26\\employee.txt",
            FileMode.Open, FileAccess.Read);
            Employee objnew = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("deserialized employee data: ");
            Console.WriteLine($"Id: {objnew.Id}, FirstName: {objnew.FirstName}," +
                $" LastName: {objnew.LastName}, Salary: {objnew.Salary} ");



            //XML Serialization and Deserialization

            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                xmlSerializer.Serialize(writer, employee);
            }

            // XML Deserialization
            Employee xmlDeserializedEmp;
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                xmlDeserializedEmp = (Employee)xmlSerializer.Deserialize(reader);
            }


            DisplayEmployee(xmlDeserializedEmp);


            Console.WriteLine("DeserializedXml Employee Data:");
            Console.WriteLine($"id: {xmlDeserializedEmp.Id}, FirstName: {xmlDeserializedEmp.FirstName}," +
                $"LastName: {xmlDeserializedEmp.LastName}, Salary: {xmlDeserializedEmp.Salary}");



        }
        // Display deserialized Employee properties
        static void DisplayEmployee(Employee employee)
        {
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}





            
 

 

 
 

             

 

 





