using System;
using System.Collections.Generic;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Models.SH.Firestore
{
    public class User : IFirestoreEntity
    {
	    public bool? Admin { get; set; }
        public string DocumentId { get; set; }
        public bool? DigerIsemirleriYetki { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public int? PersId { get; set; }
        public string Platform { get; set; }
        public string ProfilePhoto { get; set; }
        public bool? TamamlananlarYetki { get; set; }
        public string Token { get; set; }

        public IFirestoreEntity Deserialize(Dictionary<string, object> map)
        {
            User user = new User
            {
                Email = map["email"].ToString(),
                NameSurname = map["nameSurname"].ToString(),
                Platform = map["platform"].ToString(),
                ProfilePhoto = map["profilePhoto"].ToString(),
                Token = map["token"].ToString(),
            };

            return user;
        }

        public Dictionary<string, object> Serialize()
        {
            throw new NotImplementedException();
        }

    }
}
