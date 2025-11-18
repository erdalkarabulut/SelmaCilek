using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StolcuValidator : AbstractValidator<STOLCU>
    {
        #region ClientService

        #endregion ClientService

        public StolcuValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.OLCHDF).Length(1,20).NotNull();
            RuleFor(p => p.BOLNEN).NotNull();
            RuleFor(p => p.BOLLEN).NotNull();
            RuleFor(p => p.EANTKD).MaximumLength(20);
            RuleFor(p => p.EANKOD).MaximumLength(40);
            RuleFor(p => p.UGYBKD).MaximumLength(20);
            RuleFor(p => p.AGOLKD).MaximumLength(20);
            RuleFor(p => p.HCOLKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
