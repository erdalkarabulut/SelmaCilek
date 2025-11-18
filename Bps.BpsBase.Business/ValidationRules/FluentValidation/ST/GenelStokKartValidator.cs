using Bps.BpsBase.Entities.Models.ST.Single;
using FluentValidation;

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class GenelStokKartValidator : AbstractValidator<GenelStokKartModel>
    {
        public GenelStokKartValidator()
        {
            #region Stok Kart

            RuleFor(p => p.Stkart.STKODU).Length(1, 25).NotNull();
            RuleFor(p => p.Stkart.STKNAM).Length(1, 100).NotNull();
            RuleFor(p => p.Stkart.STANKD).Length(1, 20).NotNull();
            RuleFor(p => p.Stkart.STALKD).MaximumLength(20);
            RuleFor(p => p.Stkart.STMLTR).Length(1, 50).NotNull();
            RuleFor(p => p.Stkart.STEKOD).MaximumLength(50);
            RuleFor(p => p.Stkart.OLCUKD).Length(1, 20).NotNull();
            RuleFor(p => p.Stkart.SADEGK).MaximumLength(4);
            RuleFor(p => p.Stkart.SAOLKD).Length(1, 20).NotNull();
            RuleFor(p => p.Stkart.MALGKD).MaximumLength(20);
            RuleFor(p => p.Stkart.AGOLKD).MaximumLength(20);
            RuleFor(p => p.Stkart.HCOLKD).MaximumLength(20);
            RuleFor(p => p.Stkart.EANTKD).MaximumLength(20);
            RuleFor(p => p.Stkart.EANKOD).MaximumLength(40);
            RuleFor(p => p.Stkart.UGYBKD).MaximumLength(20);

            #endregion Stok Kart

            #region Depo

            RuleForEach(p => p.Stdepos).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.URYRKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.DPKODU).Length(1, 4).NotNull();
                ch.RuleFor(p => p.ENBLKJ).NotNull();
                ch.RuleFor(p => p.USESTK).NotNull();
                ch.RuleFor(p => p.BLKSTK).NotNull();
                ch.RuleFor(p => p.MIPGOS).NotNull();
                ch.RuleFor(p => p.TEDKOD).Length(1, 4).NotNull();
                ch.RuleFor(p => p.DPADRS).MaximumLength(40);
                ch.RuleFor(p => p.ULKEKD).MaximumLength(20);
            });

            #endregion Depo

            #region Maliyet

            //RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.Stkmiz.MALHSP).NotNull();
            RuleFor(p => p.Stkmiz.MALIYL).NotNull();
            RuleFor(p => p.Stkmiz.MALIAY).NotNull();

            #endregion

            #region Ölçü Tanımlama

            RuleForEach(p => p.Stolcus).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.OLCUKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.OLCHDF).Length(1, 20).NotNull();
                ch.RuleFor(p => p.BOLLEN).NotNull();
                ch.RuleFor(p => p.BOLNEN).NotNull();
            });

            #endregion

            #region Satış

            RuleForEach(p => p.Stsales).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.SPORKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.SPDGKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.ASGMIK).NotNull();
                ch.RuleFor(p => p.OLCUKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.MALGK1).MaximumLength(20);
                ch.RuleFor(p => p.MALGK2).MaximumLength(20);
                ch.RuleFor(p => p.MALGK3).MaximumLength(20);
            });

            #endregion

            #region Dil

            RuleForEach(p => p.Stnames).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.STKNAM).Length(1, 100).NotNull();
                ch.RuleFor(p => p.LANGKD).Length(1, 20).NotNull();
            });

            #endregion

            #region Muhasebe

            RuleForEach(p => p.Stmhsbs).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.STFTNO).NotNull();
                ch.RuleFor(p => p.HSPKOD).Length(1, 25).NotNull();
                ch.RuleFor(p => p.DPKODU).Length(1, 4).NotNull();
            });

            #endregion

            #region Üretim Yeri

            RuleForEach(p => p.Sturyrs).ChildRules(ch =>
            {
                //ch.RuleFor(p => p.STKODU).Length(1, 25).NotNull();
                ch.RuleFor(p => p.URYRKD).Length(1, 20).NotNull();
                ch.RuleFor(p => p.ABCGOS).MaximumLength(1);
                ch.RuleFor(p => p.STNGKD).MaximumLength(20);
                ch.RuleFor(p => p.YNSPSV).NotNull();
                ch.RuleFor(p => p.EMNSTK).NotNull();
                ch.RuleFor(p => p.MPPRTB);
                ch.RuleFor(p => p.OLCUKD).MaximumLength(20);
                ch.RuleFor(p => p.URDEPO).MaximumLength(4);
            });

            #endregion

        }
    }
}