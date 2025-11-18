using System;
using System.Web;
using Bps.Core.GlobalStaticsVariables;

namespace Bps.Core.Web.Session
{
    public static class SessionHelper
    {
        private static Boolean SystemService = false;

        #region Sessions

        public static int? SirketId
        {
            get
            {
                if (SystemService) return 0;
                return (int?)HttpContext.Current.Session["SirketId"];
            }
        }
        public static int? KarsiSirketId
        {
            get
            {
                if (SystemService) return 0;
                return (int?)HttpContext.Current.Session["KarsiSirketId"];
            }
        }
        public static bool? SirketType
        {
            get
            {
                if (SystemService) return true;
                return (bool?)HttpContext.Current.Session["SirketType"];
            }
        }

        public static int? PersId
        {
            get
            {
                if (SystemService) return 0;
                return (int?)HttpContext.Current.Session["PersId"];
            }
        }

        public static int? UserId
        {
            get
            {
                if (SystemService) return 0;
                return (int?)HttpContext.Current.Session["UserId"];
            }
        }

        public static string UserKod
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["UserKod"];
            }
        }

        public static string FirstName
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["FirstName"];
            }
        }

        public static string LastName
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["LastName"];
            }
        }

        public static string ProjeKod
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return HttpContext.Current.Session["ProjeKod"] != null ? HttpContext.Current.Session["ProjeKod"].ToString() : "";
            }
        }

        public static string ProjeTanim
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return HttpContext.Current.Session["ProjeTanim"] != null ? HttpContext.Current.Session["ProjeTanim"].ToString() : "";
            }
        }

        public static int? MenuTag
        {
            get
            {
                if (SystemService) return 0;
                return (int?)HttpContext.Current.Session["MenuTag"];
            }
        }

        public static string Email
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["Email"];
            }
        }

        public static string DilKod
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["DilKod"];
            }
        }

        public static string KaynakKod
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["KaynakKod"];
            }
        }

        public static string Role
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["Role"];
            }
        }

        public static string Depertman
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["Depertman"];
            }
        }

        public static string Pozisyon
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["Pozisyon"];
            }
        }

        public static string Theme
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["Theme"];
            }
        }

        public static string UserImgPath
        {
            get
            {
                if (SystemService) return "SİSTEM";
                return (string)HttpContext.Current.Session["UserImgPath"];
            }
        }

        public static bool? ResimVarMi
        {
            get
            {
                if (SystemService) return false;
                return (bool?)HttpContext.Current.Session["ResimVarMi"];
            }
        }

        #endregion

        public static void UserLogin(int? sirketId, int? ksId, bool sirketType, int? persId, int userId, string userKod, string firstName,
            string lastName, string projeKod, int? menuTag, string email, string dilKod, string kaynakKod,
            string role, string depertman, string pozisyon, string theme, bool resimVarMi, string imagePath)
        {
            HttpContext.Current.Session["SirketId"] = sirketId;
            HttpContext.Current.Session["UserKod"] = userKod;
            HttpContext.Current.Session["UserId"] = userId;
            HttpContext.Current.Session["FirstName"] = firstName;
            HttpContext.Current.Session["LastName"] = lastName;
            //HttpContext.Current.Session["ProjeKod"] = projeKod;
            HttpContext.Current.Session["MenuTag"] = menuTag;
            HttpContext.Current.Session["Email"] = email;
            HttpContext.Current.Session["DilKod"] = dilKod;
            HttpContext.Current.Session["KaynakKod"] = kaynakKod;
            HttpContext.Current.Session["Role"] = role;
            HttpContext.Current.Session["Depertman"] = depertman;
            HttpContext.Current.Session["Pozisyon"] = pozisyon;
            HttpContext.Current.Session["Theme"] = theme ?? "Metropolis";
            HttpContext.Current.Session["PersId"] = persId;
            HttpContext.Current.Session["ResimVarMi"] = resimVarMi;
            HttpContext.Current.Session["UserImgPath"] = imagePath;
            HttpContext.Current.Session["SirketType"] = sirketType;
            HttpContext.Current.Session["KarsiSirketId"] = KarsiSirketId;
        }

        public static Global ConvertSessiontoGlobal()
        {
            var global = new Global();
            if (HttpContext.Current.Session == null) return global;
            global.SirketId = SirketId;
            global.KarsiSirketId = KarsiSirketId;
            global.SirketType = SirketType;
            global.PersId = PersId;
            global.UserKod = UserKod;
            global.UserId = UserId;
            global.ProjeKod = ProjeKod;
            global.ProjeTanim = ProjeTanim;
            global.MenuTag = MenuTag;
            global.KaynakKod = KaynakKod;
            global.DilKod = DilKod;
            global.Role = Role;
            global.FirstName = FirstName;
            global.LastName = LastName;
            global.Email = Email;
            global.ResimVarMi = false;
            global.Depertman = Depertman;
            global.Pozisyon = Pozisyon;
            global.Theme = Theme;
            global.UserImgPath = UserImgPath;
            global.ResimVarMi = ResimVarMi ?? false;
            return global;
        }

        public static void SystemLogin()
        {
            SystemService = true;
        }

        public static void SystemLogout()
        {
            SystemService = false;
        }
    }
}