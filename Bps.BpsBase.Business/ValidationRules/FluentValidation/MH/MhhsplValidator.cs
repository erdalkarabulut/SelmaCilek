using FluentValidation;
using Bps.BpsBase.Entities.Concrete.MH;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.MH
{
    public class MhhsplValidator : AbstractValidator<MHHSPL>
    {
        #region ClientService

        #endregion ClientService

        public MhhsplValidator()
        {
            RuleFor(p => p.HSPKOD).MaximumLength(25);
            RuleFor(p => p.HSPTNM).MaximumLength(40);
            RuleFor(p => p.HSPTKD).MaximumLength(20);
            RuleFor(p => p.DVCNKD).MaximumLength(20);
            RuleFor(p => p.DGSKKD).MaximumLength(20);
            RuleFor(p => p.MGRKOD).MaximumLength(4);
            RuleFor(p => p.KDVDKD).MaximumLength(10);
            RuleFor(p => p.KMZKOD).MaximumLength(25);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
