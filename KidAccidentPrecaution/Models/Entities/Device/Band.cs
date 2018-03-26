using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidAccidentPrecaution.Models.Entities.Device
{
    public class BandResponse
    {
        public BandStatus Status { get; set; }
        public string Message { get; set; }

    }

    public class Band
    {

        public int bandId { get; set; }

        public string BandNo { get; set; }

        public string BandSLNO { get; set; }


        public string NotificationType { get; set; }


        public EmailDataSet Email { get; set; }
    }




    public enum BandStatus
    {
        Success = 1,
        Error = 0,
        Warning = -1
    }
}