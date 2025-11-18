using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CrbankValidator : AbstractValidator<CRBANK>
    {
        #region ClientService

        #endregion ClientService

        public CrbankValidator()
        {
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.BANKKD).Length(1,20).NotNull();
            RuleFor(p => p.BNSBKD).MaximumLength(20);
            RuleFor(p => p.SEHRKD).MaximumLength(20);
            RuleFor(p => p.BNKHSP).MaximumLength(50);
            RuleFor(p => p.BNIBAN).MaximumLength(50);
            RuleFor(p => p.VARSAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
