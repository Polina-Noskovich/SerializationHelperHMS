using NUnit.Framework;
using Domain.Entities;
using SerializationHelperHMS;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace SerializationTestsHMS
{
    public class JsonSerializerTests
    {
        // Тест сериализации списка пациентов в JSON
        [Test]
        public void Serialize_Patients_ListOfPatients_SerializedCorrectly()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient { Id = 1, fullName = "John", address = "123 Main St", email = "john@example.com", phone = "123-456-7890" },
                new Patient { Id = 2, fullName = "Alice", address = "456 Elm St", email = "alice@example.com", phone = "987-654-3210" }
            };

            string filePath = "D:\\c#\\HospitalManagSystem\\HospitalManagementSystem.Json\\patients.json";

            // Act
            JsonSerializationHelper.Serialize(patients, filePath);
            var loadedPatients = JsonSerializationHelper.Deserialize<List<Patient>>(filePath);

            // Assert
            ClassicAssert.IsNotNull(loadedPatients);
            ClassicAssert.AreEqual(patients.Count, loadedPatients.Count);
            for (int i = 0; i < patients.Count; i++)
            {
                ClassicAssert.AreEqual(patients[i].Id, loadedPatients[i].Id);
                ClassicAssert.AreEqual(patients[i].fullName, loadedPatients[i].fullName);
                ClassicAssert.AreEqual(patients[i].address, loadedPatients[i].address);
                ClassicAssert.AreEqual(patients[i].email, loadedPatients[i].email);
                ClassicAssert.AreEqual(patients[i].phone, loadedPatients[i].phone);
            }
        }
        // Тест сериализации списка докторов в JSON
        [Test]
        public void Serialize_Doctors_ListOfDoctors_SerializedCorrectly()
        {
            // Arrange
            var doctors = new List<Doctor>();
            {
                new Doctor(1, "John", "Doe", "john@example.com", "123-456-7890", 123, "Main St", "City1");
                new Doctor(2, "Alice", "Smith", "alice@example.com", "987-654-3210", 456, "Elm St", "City2");
            };

            string filePath = "D:\\c#\\HospitalManagSystem\\HospitalManagementSystem.Json\\doctors.json";

            // Act
            JsonSerializationHelper.Serialize(doctors, filePath);
            var loadedDoctors = JsonSerializationHelper.Deserialize<List<Doctor>>(filePath);

            // Assert
            ClassicAssert.IsNotNull(loadedDoctors);
            //Assert.That(patients.Count,Is.EqualTo(loadedPatients.Count));
            ClassicAssert.AreEqual(doctors.Count, loadedDoctors.Count);
            for (int i = 0; i < doctors.Count; i++)
            {
                ClassicAssert.AreEqual(doctors[i].Id, loadedDoctors[i].Id);
                ClassicAssert.AreEqual(doctors[i].FirstName, loadedDoctors[i].FirstName);
                ClassicAssert.AreEqual(doctors[i].LastName, loadedDoctors[i].LastName);
                ClassicAssert.AreEqual(doctors[i].Email, loadedDoctors[i].Email);
                ClassicAssert.AreEqual(doctors[i].Phone, loadedDoctors[i].Phone);
                ClassicAssert.AreEqual(doctors[i].StreetNumber, loadedDoctors[i].StreetNumber);
                ClassicAssert.AreEqual(doctors[i].StreetName, loadedDoctors[i].StreetName);
                ClassicAssert.AreEqual(doctors[i].City, loadedDoctors[i].City);
            }
        }
        // Test serialization of a single Administrator instance to JSON
        [Test]
        public void Serialize_Administrator_SerializedCorrectly()
        {
            // Arrange
            // var administrator = new Administrator(1, "adminUser", "Admin Address", "admin@example.com", 123456789);
            var administrators = new List<Administrator>();
            {
                new Administrator(1, "adminUser", "Admin Address", "admin@example.com", 123456789);
                new Administrator(2, "adminPolina", "Polina Address", "polina@example.com", 987654321);
            };

            string filePath = "D:\\c#\\HospitalManagSystem\\HospitalManagementSystem.Json\\administrator.json";

            // Act
            JsonSerializationHelper.Serialize(administrators, filePath);
            var loadedAdministrator = JsonSerializationHelper.Deserialize<List<Administrator>>(filePath);

            // Assert
            ClassicAssert.IsNotNull(loadedAdministrator);
            ClassicAssert.AreEqual(administrators.Count, loadedAdministrator.Count);
            for (int i = 0; i < administrators.Count; i++)
            {
                ClassicAssert.AreEqual(administrators[i].id, loadedAdministrator[i].id);
                ClassicAssert.AreEqual(administrators[i].userName, loadedAdministrator[i].userName);
                ClassicAssert.AreEqual(administrators[i].address, loadedAdministrator[i].address);
                ClassicAssert.AreEqual(administrators[i].email, loadedAdministrator[i].email);
                ClassicAssert.AreEqual(administrators[i].phone, loadedAdministrator[i].phone);
            }
        }

        [Test]
        public void Serialize_Appointments_ListOfAppointments_SerializedCorrectly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            var appointments = new List<Appointment>();
            {
                new Appointment(1, "Alice", "John Doe", "Pain in the heart", now);
                new Appointment(2, "John", "Alice Smith", "Headache", now);
            };
            string filePath = "D:\\c#\\HospitalManagSystem\\HospitalManagementSystem.Json\\appointments.json";

            // Act
            JsonSerializationHelper.Serialize(appointments, filePath);
            var loadedAppointments = JsonSerializationHelper.Deserialize<List<Appointment>>(filePath);

            // Assert
            ClassicAssert.IsNotNull(loadedAppointments);
            ClassicAssert.AreEqual(appointments.Count, loadedAppointments.Count);
            for (int i = 0; i < appointments.Count; i++)
            {
                ClassicAssert.AreEqual(appointments[i].DoctorID, loadedAppointments[i].DoctorID);
                ClassicAssert.AreEqual(appointments[i].PatientName, loadedAppointments[i].PatientName);
                ClassicAssert.AreEqual(appointments[i].DoctorName, loadedAppointments[i].DoctorName);
                ClassicAssert.AreEqual(appointments[i].Description, loadedAppointments[i].Description);
                ClassicAssert.AreEqual(appointments[i].DataTime, loadedAppointments[i].DataTime);
            }
        }
    }
}
