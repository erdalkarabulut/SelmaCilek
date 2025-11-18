using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.Entities;
using Newtonsoft.Json;

namespace Bps.BpsBase.Entities
{
    [Serializable]
    public class BaseEntity : IEntity
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Durum")]
        public bool ACTIVE { get; set; }

        [DisplayName("Silindi")]
        public bool SLINDI { get; set; }

        [DisplayName("Ekleyen Kullanıcı")]
        public string EKKULL { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime ETARIH { get; set; }

        [DisplayName("Değiştiren Kullanıcı")]
        public string DEKULL { get; set; }

        [DisplayName("Değişiklik Tarihi")]
        public DateTime? DTARIH { get; set; }

        [DisplayName("Kaynak Kod")]
        public string KYNKKD { get; set; }

        [DefaultValue(false)]
        [DisplayName("Control")]
        public bool CHKCTR { get; set; }
    }
}
