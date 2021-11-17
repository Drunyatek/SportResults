using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SportResults.Class
{
    public class Responce
    {
        /// <summary>
        /// Id исполнительного производства (которое мы отправляем)
        /// </summary>
        [JsonProperty("executiveproductionid")]
        public long ExecutiveProductionId;
        /// <summary>
        /// Номер исполнительного производства (которое мы отправляем)
        /// </summary>
        [JsonProperty("executiveproductionregnum")]
        public string ExecutiveProductionRegNum;
        /// <summary>
        /// Дата открытия ИП
        /// </summary>
        [JsonProperty("opendate")]
        public string OpenDate;
        /// <summary>
        /// Признак юр. лица или физ.лица/флп
        /// </summary>
        [JsonProperty("islegalsubject")]
        public int IsLegalSubject;
        /// <summary>
        /// Фамилия должника
        /// </summary>
        [JsonProperty("surname")]
        public string DebetorSurname;
        /// <summary>
        /// Имя должника
        /// </summary>
        [JsonProperty("firstname")]
        public string DebetorFirstname;
        /// <summary>
        /// Отчество должника
        /// </summary>
        [JsonProperty("lastname")]
        public string DebetorLastname;
        /// <summary>
        /// Дата рождения должника
        /// </summary>
        [JsonProperty("birthdate")]
        public string DebetorBirthdate;
        /// <summary>
        /// ИКЮЛ/РНУКН должника
        /// </summary>
        [JsonProperty("okpodebetor")]
        public string OkpoDebetor;
        /// <summary>
        /// Судебный исполнитель
        /// </summary>
        [JsonProperty("executor")]
        public string Executor;
        /// <summary>
        /// Дата формирования файла
        /// </summary>
        [JsonProperty("datecreate")]
        public string DateCreate;

        public string DebetorFullname;

        public string CarDateReg;
        public string CarNum;
        public string CarVin;
        public string CarModel;
        public string CarYear;
        public string CarDocNum;
        public string OwnerFIO;
        public string CarReg;
        public string More;
        public string SpecialMessage;
    }
}
