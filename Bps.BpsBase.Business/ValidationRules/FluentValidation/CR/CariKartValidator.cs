using Bps.BpsBase.Entities.Models.CR.Single;
using FluentValidation;

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CariKartValidator : AbstractValidator<GenelCariKartModel>
    {
        public CariKartValidator()
        {
            #region Cari

            RuleFor(p => p.CariKart.CRHRKD).Length(1, 20).NotNull();
            RuleFor(p => p.CariKart.CRKODU).Length(1, 25).NotNull();
            RuleFor(p => p.CariKart.CRUNV1).Length(1, 127).NotNull();
            RuleFor(p => p.CariKart.CRUNV2).MaximumLength(127);
            RuleFor(p => p.CariKart.CRBGKD).MaximumLength(20);
            RuleFor(p => p.CariKart.CRHSP1).MaximumLength(25);
            RuleFor(p => p.CariKart.CRHSP2).MaximumLength(25);
            RuleFor(p => p.CariKart.CRHSP3).MaximumLength(25);
            RuleFor(p => p.CariKart.CRDVCN).MaximumLength(10);
            RuleFor(p => p.CariKart.CRDVC1).MaximumLength(10);
            RuleFor(p => p.CariKart.CRDVC2).MaximumLength(10);
            RuleFor(p => p.CariKart.VERGDA).Length(1, 50).NotNull();
            RuleFor(p => p.CariKart.VERGNO).Length(1, 15).NotNull();
            RuleFor(p => p.CariKart.TSICNO).MaximumLength(50);
            RuleFor(p => p.CariKart.VERKML).MaximumLength(15);
            RuleFor(p => p.CariKart.CRAKOD).MaximumLength(25);
            RuleFor(p => p.CariKart.CRSKOD).MaximumLength(25);
            RuleFor(p => p.CariKart.GNMAIL).MaximumLength(100);
            RuleFor(p => p.CariKart.GNWEBA).MaximumLength(100);

            #endregion

            #region Yetkili

            RuleForEach(p => p.Crytkls).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.CRKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.YETADI).Length(1, 50).NotNull();
                ch.RuleFor(p => p.YETSOY).Length(1, 50).NotNull();
                ch.RuleFor(p => p.YETUNV).MaximumLength(50);
                ch.RuleFor(p => p.ISYTEL).MaximumLength(30);
                ch.RuleFor(p => p.CRDHLN).MaximumLength(30);
                ch.RuleFor(p => p.CEPTEL).MaximumLength(30);
                ch.RuleFor(p => p.ISYFAX).MaximumLength(30);
                ch.RuleFor(p => p.GNMAIL).MaximumLength(100);
            });

            #endregion

            #region Banka

            RuleForEach(p => p.Crbanks).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.CRKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.BANKKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.BNSBKD).MaximumLength(20);
                ch.RuleFor(p => p.SEHRKD).MaximumLength(20);
                ch.RuleFor(p => p.BNKHSP).MaximumLength(50);
                ch.RuleFor(p => p.BNIBAN).MaximumLength(50);
                ch.RuleFor(p => p.VARSAY).NotNull();

            });

            #endregion
        }
    }
}