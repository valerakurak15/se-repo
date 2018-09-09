using System;
using System.Text;
using System.Net;
using System.Management;
using System.Collections.Specialized;

namespace Game 
{
    class ConfSys
    {
        public static string hwid, responseHWIDstring, responseHealthString;
        public static string getHWID() {
           ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
           dsk.Get();
           hwid = dsk["VolumeSerialNumber"].ToString();
           return hwid;
      }
        public static string sendHWID()
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["HWID"] = ConfSys.getHWID();

                var response = wb.UploadValues("http://desulist.000webhostapp.com/tamagochi.php", "POST", data);
                responseHWIDstring = Encoding.UTF8.GetString(response);
            }
            return responseHWIDstring;
        }
        public static string sendHealth(int kind_health)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["HWID"] = ConfSys.getHWID();
                data["health"] = Convert.ToString(kind_health);

                var response = wb.UploadValues("http://desulist.000webhostapp.com/tamagochi.php", "POST", data);
                responseHealthString = Encoding.UTF8.GetString(response);
            }
            return responseHealthString;
        }

    }
   abstract class pet
    {
        public int getTimeBetween(DateTime pastTime)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(Convert.ToDateTime(pastTime)).TotalMinutes);
        }
        public void funcHandle(string func)
        {
            switch (func)
            {
                case "eat":
                    cat_health += 2;
                    Console.WriteLine("Pokushal.");
                    break;
                case "walk":
                    cat_health += 1;
                    Console.WriteLine("Pogulyal.");
                    break;
                default: Console.WriteLine("Error choice!."); break;
            }
        }
        protected int cat_health = 2, dog_health = 3, parrot_health = 1; 
        public abstract int checkState(DateTime pastTime, string func);
    }
    class cat : pet
    {
        public override int checkState(DateTime pastTime, string func)
        {
                funcHandle(func);
                ConfSys.sendHealth(cat_health);                                                                         
                if (getTimeBetween(pastTime) > Convert.ToInt32(ConfSys.responseHealthString))
                {
                    Console.WriteLine("Your pet dead!");
                    return 0;
                }
                return cat_health;
        }
    }
    class dog : pet
    {
        public override int checkState(DateTime pastTime, string func)
        {
            funcHandle(func);
            ConfSys.sendHealth(dog_health);
            if (getTimeBetween(pastTime) > Convert.ToInt32(ConfSys.responseHealthString))
            {
                Console.WriteLine("Your pet dead!");
                return 0;
            }
            return dog_health;
        }
    }
    class parrot : pet
    {
        public override int checkState(DateTime pastTime, string func)
        {
            funcHandle(func);
            ConfSys.sendHealth(parrot_health);
            if (getTimeBetween(pastTime) > Convert.ToInt32(ConfSys.responseHealthString))
            {
                Console.WriteLine("Your pet dead!");
                return 0;
            }
            return parrot_health;
        }
    }
}

