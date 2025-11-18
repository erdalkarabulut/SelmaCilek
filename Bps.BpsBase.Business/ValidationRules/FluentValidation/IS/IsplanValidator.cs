using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsplanValidator : AbstractValidator<ISPLAN>
    {
        #region ClientService

        #endregion ClientService

        public IsplanValidator()
        {
            RuleFor(p => p.ISPKOD).MaximumLength(20);
            RuleFor(p => p.SIRASI).NotNull();
            RuleFor(p => p.GNTARH).NotNull();
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.ISYKOD).MaximumLength(20);
            RuleFor(p => p.ISOPKD).Length(1,20).NotNull();
            RuleFor(p => p.ISMETN).MaximumLength(50);
            RuleFor(p => p.SPSTKD).Length(1,25).NotNull();
            RuleFor(p => p.MXPRKD).Length(1,25).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.URAKOD).Length(1,50).NotNull();
            RuleFor(p => p.PURKOD).MaximumLength(50);
            RuleFor(p => p.PLMKTR).NotNull();
            RuleFor(p => p.GROLBR).Length(1,20).NotNull();
            RuleFor(p => p.GNHZOB).MaximumLength(20);
            RuleFor(p => p.ISLMSB).MaximumLength(20);
            RuleFor(p => p.ISCSUB).MaximumLength(20);
            RuleFor(p => p.GCTSUB).MaximumLength(20);
            RuleFor(p => p.FLGKPN).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
