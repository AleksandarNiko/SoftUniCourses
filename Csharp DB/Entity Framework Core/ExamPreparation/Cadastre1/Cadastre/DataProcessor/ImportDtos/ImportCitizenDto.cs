using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos
{
    [JsonObject(nameof(Citizen))]
    public class ImportCitizenDto
    {
        [Required]
        [MinLength(CitizenFirstNameMinLength)]
        [MaxLength(CitizenFirstNameMaxLength)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(CitizenLastNameMinLength)]
        [MaxLength(CitizenLastNameMaxLength)]
        [JsonProperty("LastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(BirthDate))]
        public  DateTime BirthDate { get; set; }

        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        [JsonProperty(nameof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Properties))]
        public int[] Properties { get; set; } = null!;
    }
}
