using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StmaltValidator : AbstractValidator<STMALT>
    {
        #region ClientService

        #endregion ClientService

        public StmaltValidator()
        {
            RuleFor(p => p.STMLTR).Length(1,50).NotNull();
            RuleFor(p => p.STMLNM).Length(1,50).NotNull();
            RuleFor(p => p.STBKDR).Length(1,15).NotNull();
            RuleFor(p => p.STCNKD).Length(1,20).NotNull();
            RuleFor(p => p.FORMUL).MaximumLength(250);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
