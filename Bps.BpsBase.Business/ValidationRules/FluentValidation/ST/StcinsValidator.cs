using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StcinsValidator : AbstractValidator<STCINS>
    {
        #region ClientService

        #endregion ClientService

        public StcinsValidator()
        {
            RuleFor(p => p.STCSNM).Length(1,30);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
