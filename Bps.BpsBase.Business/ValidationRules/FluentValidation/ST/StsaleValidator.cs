using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StsaleValidator : AbstractValidator<STSALE>
    {
        #region ClientService

        #endregion ClientService

        public StsaleValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.SPORKD).Length(1,20).NotNull();
            RuleFor(p => p.SPDGKD).Length(1,20).NotNull();
            RuleFor(p => p.ASGMIK).NotNull();
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.MALGK1).MaximumLength(20);
            RuleFor(p => p.MALGK2).MaximumLength(20);
            RuleFor(p => p.MALGK3).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
