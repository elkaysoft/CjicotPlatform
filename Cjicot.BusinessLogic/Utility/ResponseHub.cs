using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Presentation.Utility
{
    public class ResponseHub
    {
        public static string RESPONSECODE00 = "00";
        public static string RESPONSEMESSAGE00 = "SUCCESSFUL";

        public static string RESPONSECODE01 = "01";
        public static string RESPONSEMESSAGE01 = "Sorry, we are unable to process, pls try again later";

        public static string RESPONSECODE02 = "02";
        public static string RESPONSEMESSAGE02 = "Custom Validation Error";


        public static string RESPONSECODE99 = "99";
        public static string RESPONSEMESSAGE99 = "Ooops! Something went wrong, pls try again later";
    }
}
