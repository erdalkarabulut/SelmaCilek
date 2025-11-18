using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using FluentValidation;

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SiparisKayitValidator : AbstractValidator<SiparisKayitModel>
    {
        public SiparisKayitValidator()
        {
            #region Baslik

            RuleFor(p => p.Baslik.SPORKD).MaximumLength(20);
            RuleFor(p => p.Baslik.SPDGKD).MaximumLength(20);
            RuleFor(p => p.Baslik.SPHRTP).NotNull();
            RuleFor(p => p.Baslik.SPFTNO).NotNull();
            RuleFor(p => p.Baslik.EVRAKN).MaximumLength(50);
            RuleFor(p => p.Baslik.BELGEN).MaximumLength(20);
            RuleFor(p => p.Baslik.BELTRH).NotNull();
            RuleFor(p => p.Baslik.CRKODU).MaximumLength(25);
            RuleFor(p => p.Baslik.MALTES).MaximumLength(25);
            RuleFor(p => p.Baslik.GRDEPO).MaximumLength(4);
            RuleFor(p => p.Baslik.CKDEPO).MaximumLength(4);
            RuleFor(p => p.Baslik.GNACIK).MaximumLength(200);
            RuleFor(p => p.Baslik.STFYNO).NotNull();
            RuleFor(p => p.Baslik.TSEVRK).MaximumLength(50);

            #endregion

            #region Kalem

            RuleForEach(p => p.Kalems).ChildRules(ch =>
            {
                ch.RuleFor(p => p.SPORKD).MaximumLength(20);
                ch.RuleFor(p => p.SPDGKD).MaximumLength(20);
                ch.RuleFor(p => p.EVRAKN).MaximumLength(50);
                ch.RuleFor(p => p.BELGEN).MaximumLength(20);
                ch.RuleFor(p => p.CRHRKD).MaximumLength(20);
                ch.RuleFor(p => p.CRKODU).MaximumLength(25);
                ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.STKNAM).Length(1, 100).NotNull();
                ch.RuleFor(p => p.STFYNO).NotNull();
                ch.RuleFor(p => p.GRDEPO).MaximumLength(4);
                ch.RuleFor(p => p.CKDEPO).MaximumLength(4);
                ch.RuleFor(p => p.AGOLKD).MaximumLength(20);
                ch.RuleFor(p => p.PARTIN).MaximumLength(50);
                ch.RuleFor(p => p.ISM1KD).MaximumLength(20);
                ch.RuleFor(p => p.ISM2KD).MaximumLength(20);
                ch.RuleFor(p => p.ISM3KD).MaximumLength(20);
                ch.RuleFor(p => p.DVCNKD).MaximumLength(10);
                ch.RuleFor(p => p.STDVCN).MaximumLength(20);
                ch.RuleFor(p => p.OLCUKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.GROLBR).MaximumLength(20);
                ch.RuleFor(p => p.TSEVRK).MaximumLength(50);
                ch.RuleFor(p => p.GNACIK).MaximumLength(200);
            });

            #endregion
        }
    }
}
