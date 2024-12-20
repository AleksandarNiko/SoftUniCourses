﻿using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.DTOs.Import
{
    [XmlType("User")]
    public class ImportUsersDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
